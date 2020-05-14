using OperatingSystem = Vultr.API.Models.Responses.OperatingSystem;
using System.Collections.Generic;
using Vultr.API.Extensions;
using Vultr.API.Models.Responses;

namespace Vultr.API.Clients
{
    public class OperatingSystemClient
    {
        private string ApiKey { get; }

        public OperatingSystemClient(string apiKey)
        {
            ApiKey = apiKey;
        }

        /// <summary>
        /// Retrieve a list of available operating systems. If the "windows" flag is
        /// true, a Windows license will be included with the instance, which will
        /// increase the cost.
        /// </summary>
        /// <returns>List of available operating systems.</returns>
        public OperatingSystemResult GetOperatingSystems()
        {
            var response = ApiClient.ApiExecute<
                Dictionary<int, OperatingSystem>>("os/list", ApiKey);

            return new OperatingSystemResult() {
                ApiResponse = response.Item1,
                OperatingSystems = response.Item2
            };
        }
    }
}
