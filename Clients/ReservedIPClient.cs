using System.Collections.Generic;
using Vultr.API.Models.Responses;

namespace Vultr.API.Clients
{
    public class ReservedIPClient
    {
        private string ApiKey { get; }

        public ReservedIPClient(string apiKey)
        {
            ApiKey = apiKey;
        }

        /// <summary>
        /// List all the active reserved IPs on this account. The "subnet_size" field is the size of the network assigned to this subscription. This will typically be a /64 for IPv6, or a /32 for IPv4.
        /// </summary>
        /// <returns>List of all the active reserved IPs on this account.</returns>
        public ReservedIPResult GetReservedIPs()
        {
            var response = Extensions.ApiClient.ApiExecute<Dictionary<string, ReservedIP>>(
                "reservedip/list", ApiKey);
            return new ReservedIPResult()
            {
                ApiResponse = response.Item1,
                ReservedIPs = response.Item2
            };
        }

        /// <summary>
        /// Create a new reserved IP. Reserved IPs can only be used within the same datacenter for which they were created.
        /// </summary>
        /// <param name="DCID">Location to create this reserved IP in.</param>
        /// <param name="ip_type">'v4' or 'v6' Type of reserved IP to create</param>
        /// <param name="label">Label for this reserved IP.</param>
        /// <returns>ReservedIP element with only SUBID.</returns>
        public ReservedIPCreateResult CreateReservedIp(int DCID, IPTYPE ip_type, string label)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("DCID", DCID),
                new KeyValuePair<string, object>("ip_type", ip_type.ToString()),
                new KeyValuePair<string, object>("label", label)
            };

            var response = Extensions.ApiClient.ApiExecute<ReservedIP>(
                "reservedip/create", ApiKey, args, "POST");
            return new ReservedIPCreateResult()
            {
                ApiResponse = response.Item1,
                ReservedIP = response.Item2
            };
        }

        /// <summary>
        /// Convert an existing IP on a subscription to a reserved IP. Returns the SUBID of the newly created reserved IP.
        /// </summary>
        /// <param name="SUBID">SUBID of the server that currently has the IP address you want to convert</param>
        /// <param name="ip_address">IP address you want to convert (v4 must be a /32, v6 must be a /64)</param>
        /// <param name="label">Label for this reserved IP.</param>
        /// <returns>ReservedIP element with only SUBID.</returns>
        public ReservedIPConvertResult ConvertReservedIp(int SUBID, string ip_address, string label)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("SUBID", SUBID),
                new KeyValuePair<string, object>("ip_address", ip_address),
                new KeyValuePair<string, object>("label", label)
            };

            var response = Extensions.ApiClient.ApiExecute<ReservedIP>(
                "reservedip/convert", ApiKey, args, "POST");
            return new ReservedIPConvertResult()
            {
                ApiResponse = response.Item1,
                ReservedIP = response.Item2
            };
        }

        /// <summary>
        /// Attach a reserved IP to an existing subscription. This feature operates normally when networking conditions are stable, but it is not reliable for conditions when high availability is needed. For HA, see our High Availability on Vultr with Floating IP and BGP guide.
        /// </summary>
        /// <param name="attach_SUBID">Unique identifier of the target server.</param>
        /// <param name="ip_address">Reserved IP to be attached. Include the subnet size in this parameter (e.g: /32 or /64).</param>
        /// <returns>No response, check HTTP result code.</returns>
        public ReservedIPUpdateResult AttachReservedIp(int attach_SUBID, string ip_address)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("attach_SUBID", attach_SUBID),
                new KeyValuePair<string, object>("ip_address", ip_address)
            };

            var response = Extensions.ApiClient.ApiExecute<ReservedIP>(
                "reservedip/attach", ApiKey, args, "POST");
            return new ReservedIPUpdateResult()
            {
                ApiResponse = response.Item1
            };
        }

        /// <summary>
        /// Detach a reserved IP to an existing subscription. This feature operates normally when networking conditions are stable, but it is not reliable for conditions when high availability is needed. For HA, see our High Availability on Vultr with Floating IP and BGP guide.
        /// </summary>
        /// <param name="detach_SUBID">Unique identifier of the target server.</param>
        /// <param name="ip_address">Reserved IP to be detached. Include the subnet size in this parameter (e.g: /32 or /64).</param>
        /// <returns>No response, check HTTP result code.</returns>
        public ReservedIPUpdateResult DetachReservedIp(int detach_SUBID, string ip_address)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("detach_SUBID", detach_SUBID),
                new KeyValuePair<string, object>("ip_address", ip_address)
            };

            var response = Extensions.ApiClient.ApiExecute<ReservedIP>(
                "reservedip/detach", ApiKey, args, "POST");
            return new ReservedIPUpdateResult()
            {
                ApiResponse = response.Item1
            };
        }

        /// <summary>
        /// Remove a reserved IP from your account. After making this call, you will not be able to recover the IP address.
        /// </summary>
        /// <param name="ip_address">Reserved IP to remove from your account.</param>
        /// <returns>No response, check HTTP result code.</returns>
        public ReservedIPUpdateResult DeleteReservedIp(string ip_address)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("ip_address", ip_address)
            };

            var response = Extensions.ApiClient.ApiExecute<ReservedIP>(
                "reservedip/destroy", ApiKey, args, "POST");
            return new ReservedIPUpdateResult()
            {
                ApiResponse = response.Item1
            };
        }
    }
}
