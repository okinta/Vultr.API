using System.Collections.Generic;
using Vultr.API.Extensions;
using Vultr.API.Models;
using Vultr.Clients;

namespace Vultr.API.Clients
{
    public class ApplicationClient : BaseClient
    {
        public ApplicationClient(string apiKey, string apiURL) : base(apiKey, apiURL) { }

        /// <summary>
        /// Retrieve a list of available applications. These refer to applications that can be launched when creating a Vultr VPS.
        /// </summary>
        /// <returns>Returns application list and HTTP API Respopnse.</returns>
        public ApplicationResult GetApplications()
        {
            var response = ApiClient.ApiExecute<
                Dictionary<string, Application>>("app/list", ApiKey);
            return new ApplicationResult()
            {
                ApiResponse = response.Item1,
                Applications = response.Item2
            };
        }
    }
}
