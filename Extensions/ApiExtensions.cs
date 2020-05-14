using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Web;
using System;

namespace Vultr.API.Extensions
{
    public enum ApiMethod
    {
        GET,
        POST,
        PUT
    }

    public static class ApiClient
    {
        public const string VultrApiUrl = "https://api.vultr.com/v1/";
        private static readonly HttpClient Client = new HttpClient();

        /// <summary>
        /// Executes a Vultr API call and processes a JSON result.
        /// </summary>
        /// <typeparam name="T">The class type representing the expected JSON
        /// result.</typeparam>
        /// <param name="accessPoint">The Vultr API endpoint to hit.</param>
        /// <param name="apiKey">The Vultr API key to use.</param>
        /// <param name="parameters">Parameters to send along with the request.</param>
        /// <param name="method">The type of request to make.</param>
        /// <returns>The API call response alonside the converted JSON result as
        /// <typeparamref name="T"/>.</returns>
        /// <exception cref="HttpRequestException">If Vultr returns a bad status
        /// code.</exception>
        public static Tuple<HttpResponseMessage, T> ApiExecute<T>(
            string accessPoint,
            string apiKey,
            List<KeyValuePair<string, object>> parameters = null,
            string method = "GET")
        {
            var apiMethod = method switch
            {
                "GET" => ApiMethod.GET,
                "POST" => ApiMethod.POST,
                "PUT" => ApiMethod.PUT,
                _ => throw new ArgumentException(
                    string.Format("Unknown method {0}", method)),
            };

            var response = ApiExecute(
                accessPoint, apiKey, parameters, apiMethod);
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException(
                    string.Format("{0}: {1}", response.StatusCode, content));
            }

            return new Tuple<HttpResponseMessage, T>(
                response,
                JsonConvert.DeserializeObject<T>(
                    (content ?? "") == "[]" ? "{}" : content)
            );
        }

        /// <summary>
        /// Executes a Vultr API call.
        /// </summary>
        /// <param name="accessPoint">The Vultr API endpoint to hit.</param>
        /// <param name="apiKey">The Vultr API key to use.</param>
        /// <param name="parameters">Parameters to send along with the request.</param>
        /// <param name="method">The type of request to make.</param>
        /// <returns>The API call response.</returns>
        private static HttpResponseMessage ApiExecute(
            string accessPoint,
            string apiKey,
            List<KeyValuePair<string, object>> parameters,
            ApiMethod method)
        {
            var url = VultrApiUrl + accessPoint;
            var request = new HttpRequestMessage();
            request.Headers.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(apiKey))
            {
                request.Headers.Add("API-Key", apiKey);
            }

            var values = new Dictionary<string, string>();
            if (parameters != null)
            {
                foreach (var pair in parameters)
                {
                    var value = Convert(pair.Value);
                    if (!string.IsNullOrEmpty(value))
                    {
                        values.Add(pair.Key, value);
                    }
                }
            }

            if (method == ApiMethod.POST)
            {
                request.RequestUri = new Uri(url);
                request.Method = HttpMethod.Post;
                request.Content = new FormUrlEncodedContent(values);
            }
            else if (method == ApiMethod.PUT)
            {
                request.RequestUri = new Uri(url);
                request.Method = HttpMethod.Put;
                request.Content = new FormUrlEncodedContent(values);
            }
            else if (method == ApiMethod.GET)
            {
                request.Method = HttpMethod.Get;

                var query = HttpUtility.ParseQueryString("");
                foreach (var pair in values)
                {
                    query[pair.Key] = pair.Value;
                }

                var builder = new UriBuilder(url) { Query = query.ToString() };
                request.RequestUri = builder.Uri;
            }
            else
            {
                throw new NotImplementedException(
                    string.Format("{0} method is not supported", method));
            }

            return Client.SendAsync(request).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Converts the given value to something Vultr API can understand.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        private static string Convert(object value)
        {
            if (value is null)
            {
                return "";
            }

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
