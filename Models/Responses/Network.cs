using System.Collections.Generic;
using System.Net.Http;

namespace Vultr.API.Models.Responses
{
    public class Network
    {
        public string DCID { get; set; }
        public string NETWORKID { get; set; }
        public string date_created { get; set; }
        public string description { get; set; }
        public string v4_subnet { get; set; }
        public int v4_subnet_mask { get; set; }
    }

    public struct NetworkCreateResult
    {
        public Network Network { get; set; }
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public struct NetworkDeleteResult
    {
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public struct NetworkResult
    {
        public Dictionary<string, Network> Networks { get; set; }
        public HttpResponseMessage ApiResponse { get; set; }
    }
}
