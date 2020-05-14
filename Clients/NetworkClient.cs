using System.Collections.Generic;
using Vultr.API.Models;
using Vultr.Clients;

namespace Vultr.API.Clients
{
    public class NetworkClient : BaseClient
    {
        public NetworkClient(string apiKey, string apiURL) : base(apiKey, apiURL) { }

        /// <summary>
        /// List all private networks on the current account.
        /// </summary>
        /// <returns>List of all private networks on the current account.</returns>
        public NetworkResult GetNetworks()
        {
            var response = ApiExecute<Dictionary<string, Network>>(
                "network/list", ApiKey);
            return new NetworkResult()
            {
                ApiResponse = response.Item1,
                Networks = response.Item2
            };
        }

        /// <summary>
        /// Create a new private network. A private network can only be used at the location for which it was created.
        /// </summary>
        /// <returns>Network element with only NETWORKID.</returns>
        public NetworkCreateResult CreateNetwork(Network Network)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("DCID", Network.DCID),
                new KeyValuePair<string, object>("description", Network.description),
                new KeyValuePair<string, object>("v4_subnet", Network.v4_subnet),
                new KeyValuePair<string, object>("v4_subnet_mask", Network.v4_subnet_mask)
            };

            var response = ApiExecute<Network>(
                "network/create", ApiKey, args, ApiMethod.POST);
            return new NetworkCreateResult()
            {
                ApiResponse = response.Item1,
                Network = response.Item2
            };
        }

        /// <summary>
        /// Destroy (delete) a private network. Before destroying, a network must be disabled from all instances. See Server Functions DisablePrivateNetwork().
        /// </summary>
        /// <param name="NetworkId">Unique identifier for this network.  These can be found using the GetNetworks() call.</param>
        /// <returns>No response, check HTTP result code.</returns>
        public NetworkDeleteResult DeleteNetwork(string NetworkId)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("NETWORKID", NetworkId)
            };

            var response = ApiExecute<Network>(
                "network/destroy", ApiKey, args, ApiMethod.POST);
            return new NetworkDeleteResult()
            {
                ApiResponse = response.Item1
            };
        }
    }
}
