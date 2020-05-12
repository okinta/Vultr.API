using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Vultr.API.Models.Responses;

namespace Vultr.API.Clients
{
    public class ApplicationClient
    {
        private readonly string _ApiKey;

        public ApplicationClient(string ApiKey)
        {
            _ApiKey = ApiKey;
        }

        /// <summary>
        /// Retrieve a list of available applications. These refer to applications that can be launched when creating a Vultr VPS.
        /// </summary>
        /// <returns>Returns application list and HTTP API Respopnse.</returns>
        public ApplicationResult GetApplications()
        {
            var answer = new ApplicationResult();
            var httpResponse = Extensions.ApiClient.ApiExecute("app/list", _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
                answer.Applications = JsonConvert.DeserializeObject<Dictionary<string, Application>>(st);
            }

            return new ApplicationResult() { ApiResponse = httpResponse, Applications = answer.Applications };
        }
    }
}