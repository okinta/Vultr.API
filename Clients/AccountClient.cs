using Vultr.API.Models;
using Vultr.Clients;

namespace Vultr.API.Clients
{
    public class AccountClient : BaseClient
    {
        public AccountClient(string apiKey, string apiURL) : base(apiKey, apiURL) { }

        /// <summary>
        /// Retrieve information about the current account.
        /// </summary>
        /// <returns>Returns account information and HTTP API Respopnse.</returns>
        public AccountResult GetInfo()
        {
            var response = ApiExecute<Account>(
                "account/info", ApiKey);
            return new AccountResult()
            {
                ApiResponse = response.Item1,
                Account = response.Item2
            };
        }
    }
}
