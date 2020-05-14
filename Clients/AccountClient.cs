using Vultr.API.Models.Responses;

namespace Vultr.API.Clients
{
    public class AccountClient
    {
        private string ApiKey { get; }

        public AccountClient(string apiKey)
        {
            ApiKey = apiKey;
        }

        /// <summary>
        /// Retrieve information about the current account.
        /// </summary>
        /// <returns>Returns account information and HTTP API Respopnse.</returns>
        public AccountResult GetInfo()
        {
            var response = Extensions.ApiClient.ApiExecute<Account>(
                "account/info", ApiKey);
            return new AccountResult()
            {
                ApiResponse = response.Item1,
                Account = response.Item2
            };
        }
    }
}