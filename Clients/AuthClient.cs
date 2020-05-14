using Vultr.API.Extensions;
using Vultr.API.Models;

namespace Vultr.API.Clients
{
    public class AuthClient
    {
        private string ApiKey { get; }

        public AuthClient(string apiKey)
        {
            ApiKey = apiKey;
        }

        /// <summary>
        /// Retrieve information about the current API key.
        /// </summary>
        /// <returns>Returns API key details and HTTP API Respopnse.</returns>
        public AuthResult GetInfo()
        {
            var response = ApiClient.ApiExecute<Auth>(
                "auth/info", ApiKey);
            return new AuthResult()
            {
                ApiResponse = response.Item1,
                Auth = response.Item2
            };
        }
    }
}
