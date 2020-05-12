using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Vultr.API.Extensions
{
    public class ApiClient
    {
        public const string VultrApiUrl = "https://api.vultr.com/v1/";
        public const int ConnectionLimit = 100;

        /// <summary>
        /// Executes a Vultr API call.
        /// </summary>
        /// <param name="AccessPoint">The Vultr API endpoint to hit.</param>
        /// <param name="ApiKey">The Vultr API key to use.</param>
        /// <param name="Parameters">Parameters to send along with the request.</param>
        /// <param name="Method">The type of request to make.</param>
        /// <returns>The API call response.</returns>
        public static HttpWebResponse ApiExecute(
            string AccessPoint,
            string ApiKey, List<KeyValuePair<string, object>> Parameters = null,
            string Method = "GET")
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.DefaultConnectionLimit = ConnectionLimit;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(
                VultrApiUrl + AccessPoint);
            httpWebRequest.UserAgent = "VultrAPI.Net";
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = Method;

            if (string.IsNullOrWhiteSpace(ApiKey) == false)
            {
                httpWebRequest.Headers.Add("API-Key", ApiKey);
            }

            if ((Method ?? "") == "GET")
            {
                if (Parameters != null)
                {
                    foreach (var pair in Parameters)
                    {
                        if (pair.Value != null)
                        {
                            httpWebRequest.Headers.Add(pair.Key, Convert(pair.Value));
                        }
                    }
                }
            }
            else if (Parameters != null)
            {
                var paramStrings = new List<string>();
                foreach (var pair in Parameters)
                {
                    if (pair.Value != null)
                    {
                        paramStrings.Add(Convert(pair.Value));
                    }
                }

                var postData = string.Join('&', paramStrings);
                var encoding = new UTF8Encoding();
                var byteData = encoding.GetBytes(postData);
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.ContentLength = byteData.Length;

                var postreqstream = httpWebRequest.GetRequestStream();
                postreqstream.Write(byteData, 0, byteData.Length);
                postreqstream.Close();
            }

            HttpWebResponse httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            return httpResponse;
        }

        /// <summary>
        /// Executes a Vultr API call and processes a JSON result.
        /// </summary>
        /// <typeparam name="T">The class type representing the expected JSON
        /// result.</typeparam>
        /// <param name="AccessPoint">The Vultr API endpoint to hit.</param>
        /// <param name="ApiKey">The Vultr API key to use.</param>
        /// <param name="Parameters">Parameters to send along with the request.</param>
        /// <param name="Method">The type of request to make.</param>
        /// <returns>The API call response alonside the converted JSON result as
        /// <typeparamref name="T"/>.</returns>
        /// <exception cref="HttpRequestException">If Vultr returns a bad status
        /// code.</exception>
        public static Tuple<HttpWebResponse, T> ApiExecute<T>(
            string AccessPoint,
            string ApiKey, List<KeyValuePair<string, object>> Parameters = null,
            string Method = "GET")
        {
            var httpResponse = ApiExecute(
                AccessPoint, ApiKey, Parameters, Method);

            string content;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                content = streamReader.ReadToEnd();
            }

            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException(
                    string.Format("{0}: {1}", httpResponse.StatusCode, content));
            }

            return new Tuple<HttpWebResponse, T>(
                httpResponse,
                JsonConvert.DeserializeObject<T>(
                    (content ?? "") == "[]" ? "{}" : content)
            );
        }

        /// <summary>
        /// Converts the given value to something Vultr API can understand.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        private static string Convert(object value)
        {
            if (value.GetType() == typeof(bool))
            {
                return (bool)value ? "yes" : "no";
            }

            if (value.GetType() == typeof(string) || value.GetType() == typeof(int))
            {
                return value.ToString();
            }

            throw new ArgumentException(
                string.Format("unknown type: {0}", value), "value");
        }
    }
}