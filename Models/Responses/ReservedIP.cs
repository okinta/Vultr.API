using System.Collections.Generic;
using System.Net;

namespace Vultr.API.Models.Responses
{
    public class ReservedIP
    {
        public int SUBID { get; set; }
        public int DCID { get; set; }
        public string IPType { get; set; }
        public string Subnet { get; set; }
        public int SubnetSize { get; set; }
        public string Label { get; set; }
        public int AttachedSUBID { get; set; }
    }

    public struct ReservedIPResult
    {
        public Dictionary<string, ReservedIP> ReservedIPs { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct ReservedIPCreateResult
    {
        public ReservedIP ReservedIP { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct ReservedIPConvertResult
    {
        public ReservedIP ReservedIP { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct ReservedIPUpdateResult
    {
        public HttpWebResponse ApiResponse { get; set; }
    }
}