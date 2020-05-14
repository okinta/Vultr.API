using System.Collections.Generic;
using System.Net.Http;

namespace Vultr.API.Models.Responses
{
    public class ReservedIP
    {
        public int SUBID { get; set; }
        public int DCID { get; set; }
        public string ip_type { get; set; }
        public string subnet { get; set; }
        public int subnet_size { get; set; }
        public string label { get; set; }
        public int attached_SUBID { get; set; }
    }

    public struct ReservedIPResult
    {
        public Dictionary<string, ReservedIP> ReservedIPs { get; set; }
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public struct ReservedIPCreateResult
    {
        public ReservedIP ReservedIP { get; set; }
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public struct ReservedIPConvertResult
    {
        public ReservedIP ReservedIP { get; set; }
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public struct ReservedIPUpdateResult
    {
        public HttpResponseMessage ApiResponse { get; set; }
    }
}
