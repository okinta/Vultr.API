using System.Collections.Generic;
using System.Net;

namespace Vultr.API.Models.Responses
{
    public class Network
    {
        public string DCID { get; set; }
        public string NetworkID { get; set; }
        public string DateCreated { get; set; }
        public string Description { get; set; }
        public string V4Subnet { get; set; }
        public int V4SubnetMask { get; set; }
    }

    public struct NetworkCreateResult
    {
        public Network Network { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct NetworkDeleteResult
    {
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct NetworkResult
    {
        public Dictionary<string, Network> Networks { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }
}