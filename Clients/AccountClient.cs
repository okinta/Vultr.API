using System.IO;
using Newtonsoft.Json;
using Vultr.API.Models.Responses;

namespace Vultr.API.Clients
{
    public class AccountClient
    {
        private readonly string _ApiKey;

        public AccountClient(string ApiKey)
        {
            _ApiKey = ApiKey;
        }

        /// <summary>
        /// Retrieve information about the current account.
        /// </summary>
        /// <returns>Returns account information and HTTP API Respopnse.</returns>
        public AccountResult GetInfo()
        {
            var answer = new Account();
            var httpResponse = Extensions.ApiClient.ApiExecute("account/info", _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    answer = JsonConvert.DeserializeObject<Account>(streamReader.ReadToEnd());
                }
            }

            return new AccountResult() { ApiResponse = httpResponse, Account = answer };
        }
    }
}