using Vultr.API.Extensions;
using Vultr.API.Models;
using Vultr.Clients;

namespace Vultr.API.Clients
{
    public class AuthClient : BaseClient
    {
        public AuthClient(string apiKey, string apiURL) : base(apiKey, apiURL) { }

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
