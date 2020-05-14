using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using Newtonsoft.Json;

namespace Vultr.Clients
{
    /// <summary>
    /// Represents the different types of requests this library can make to the Vultr API.
    /// </summary>
    public enum ApiMethod
    {
        GET,
        POST
    }

    /// <summary>
    /// Describes methods to interact with the Vultr API. Intended as a base class for
    /// other Vultr client classes.
    /// </summary>
    public abstract class BaseClient
    {
        /// <summary>
        /// Gets the API key used for interacting with Vultr.
        /// </summary>
        protected string ApiKey { get; }

        /// <summary>
        /// Gets the Vultr API URL.
        /// </summary>
        protected string ApiURL { get; }

        /// <summary>
        /// The HttpClient instance to use for requests.
        /// </summary>
        protected static readonly HttpClient Client = new HttpClient();

        /// <summary>
        /// Instantiates a new instance.
        /// </summary>
        /// <param name="apiKey">The API key to use to interact with Vultr.</param>
        /// <param name="apiURL">The Vultr API endpoint to use.</param>
        protected BaseClient(string apiKey, string apiURL)
        {
            ApiKey = apiKey;
            ApiURL = apiURL;
        }

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
        protected Tuple<HttpResponseMessage, T> ApiExecute<T>(
            string accessPoint,
            string apiKey,
            List<KeyValuePair<string, object>> parameters = null,
            ApiMethod method = ApiMethod.GET)
        {
            var response = ApiExecute(accessPoint, apiKey, parameters, method);
            var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            if (response.StatusCode != HttpStatusCode.OK)
                throw new HttpRequestException(
                    string.Format("{0}: {1}", response.StatusCode, content));

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
        private HttpResponseMessage ApiExecute(
            string accessPoint,
            string apiKey,
            List<KeyValuePair<string, object>> parameters,
            ApiMethod method)
        {
            var url = ApiURL + accessPoint;
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
                throw new NotImplementedException(
                    string.Format("{0} method is not supported", method));

            return Client.SendAsync(request).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Converts the given value to something Vultr API can understand.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        private static string Convert(object value)
        {
            if (value is null) return "";

            if (value.GetType() == typeof(bool))
                return (bool)value ? "yes" : "no";

            if (value.GetType() == typeof(string) || value.GetType() == typeof(int))
                return value.ToString();

            throw new ArgumentException(
                string.Format("unknown type: {0}", value), "value");
        }
    }
}
