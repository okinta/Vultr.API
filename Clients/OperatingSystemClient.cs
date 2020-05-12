using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Vultr.API.Models.Responses;
using OperatingSystem = Vultr.API.Models.Responses.OperatingSystem;

namespace Vultr.API.Clients
{
    public class OperatingSystemClient
    {
        private readonly string _ApiKey;

        public OperatingSystemClient(string ApiKey)
        {
            _ApiKey = ApiKey;
        }

        /// <summary>
        /// Retrieve a list of available operating systems. If the "windows" flag is true, a Windows license will be included with the instance, which will increase the cost.
        /// </summary>
        /// <returns>List of available operating systems.</returns>
        public OperatingSystemResult GetOperatingSystems()
        {
            var answer = new Dictionary<int, OperatingSystem>();
            var httpResponse = Extensions.ApiClient.ApiExecute("regions/list?availability=yes", _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                    answer = JsonConvert.DeserializeObject<Dictionary<int, OperatingSystem>>((st ?? "") == "[]" ? "{}" : st);
                }
            }

            return new OperatingSystemResult() { ApiResponse = httpResponse, OperatingSystems = answer };
        }
    }
}