using System.IO;
using Newtonsoft.Json;
using Vultr.API.Models.Responses;

namespace Vultr.API.Clients
{
    public class AuthClient
    {
        private readonly string _ApiKey;

        public AuthClient(string ApiKey)
        {
            _ApiKey = ApiKey;
        }


        /// <summary>
        /// Retrieve information about the current API key.
        /// </summary>
        /// <returns>Returns API key details and HTTP API Respopnse.</returns>
        public AuthResult GetInfo()
        {
            var answer = new AuthResult();
            var httpResponse = Extensions.ApiClient.ApiExecute("auth/info", _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                    answer.Auth = JsonConvert.DeserializeObject<Auth>(st);
                }
            }

            return new AuthResult() { ApiResponse = httpResponse, Auth = answer.Auth };
        }
    }
}