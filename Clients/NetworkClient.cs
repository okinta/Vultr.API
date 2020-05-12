using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Vultr.API.Models.Responses;

namespace Vultr.API.Clients
{
    public class NetworkClient
    {
        private readonly string _ApiKey;

        public NetworkClient(string ApiKey)
        {
            _ApiKey = ApiKey;
        }

        /// <summary>
        /// List all private networks on the current account.
        /// </summary>
        /// <returns>List of all private networks on the current account.</returns>
        public NetworkResult GetNetworks()
        {
            var answer = new Dictionary<string, Network>();
            var httpResponse = Extensions.ApiClient.ApiExecute("network/list", _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                    answer = JsonConvert.DeserializeObject<Dictionary<string, Network>>((st ?? "") == "[]" ? "{}" : st);
                }
            }

            return new NetworkResult() { ApiResponse = httpResponse, Networks = answer };
        }

        /// <summary>
        /// Create a new private network. A private network can only be used at the location for which it was created.
        /// </summary>
        /// <returns>Network element with only NETWORKID.</returns>
        public NetworkCreateResult CreateNetwork(Network Network)
        {
            var dict = new List<KeyValuePair<string, object>>();
            dict.Add(new KeyValuePair<string, object>("DCID", Network.DCID));
            dict.Add(new KeyValuePair<string, object>("description", Network.description));
            dict.Add(new KeyValuePair<string, object>("v4_subnet", Network.v4_subnet));
            dict.Add(new KeyValuePair<string, object>("v4_subnet_mask", Network.v4_subnet_mask));
            var answer = new Network();
            var httpResponse = Extensions.ApiClient.ApiExecute("network/create", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                    answer = JsonConvert.DeserializeObject<Network>((st ?? "") == "[]" ? "{}" : st);
                }
            }

            return new NetworkCreateResult() { ApiResponse = httpResponse, Network = answer };
        }

        /// <summary>
        /// Destroy (delete) a private network. Before destroying, a network must be disabled from all instances. See Server Functions DisablePrivateNetwork().
        /// </summary>
        /// <param name="NetworkId">Unique identifier for this network.  These can be found using the GetNetworks() call.</param>
        /// <returns>No response, check HTTP result code.</returns>
        public NetworkDeleteResult DeleteNetwork(string NetworkId)
        {
            var dict = new List<KeyValuePair<string, object>>();
            dict.Add(new KeyValuePair<string, object>("NETWORKID", NetworkId));
            var httpResponse = Extensions.ApiClient.ApiExecute("network/destroy", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                }
            }

            return new NetworkDeleteResult() { ApiResponse = httpResponse };
        }
    }
}