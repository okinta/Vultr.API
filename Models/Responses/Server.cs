using System.Collections.Generic;
using System.Net;

namespace Vultr.API.Models.Responses
{
    public class Server
    {
        public string ID { get; set; }
        public string OS { get; set; }
        public string Ram { get; set; }
        public string Disk { get; set; }
        public string MainIP { get; set; }
        public string VCPUCount { get; set; }
        public string Location { get; set; }
        public string DCID { get; set; }
        public string DefaultPassword { get; set; }
        public string DateCreated { get; set; }
        public string PendingCharges { get; set; }
        public string Status { get; set; }
        public string CostPerMonth { get; set; }
        public double CurrentBandwidthGB { get; set; }
        public string AllowedBandwidthGB { get; set; }
        public string NetmaskV4 { get; set; }
        public string GatewayV4 { get; set; }
        public string PowerStatus { get; set; }
        public string ServerState { get; set; }
        public string VPSPLANID { get; set; }
        public string V6MainIP { get; set; }
        public string V6NetworkSize { get; set; }
        public string V6Network { get; set; }
        public V6Networks[] V6Networks { get; set; }
        public string Label { get; set; }
        public string InternalIP { get; set; }
        public string KvmUrl { get; set; }
        public string AutoBackups { get; set; }
        public string Tag { get; set; }
        public string OSID { get; set; }
        public string AppID { get; set; }
        public string FirewallGroupID { get; set; }
    }

    public class BandWidth
    {
        public string[][] IncomingBytes { get; set; }
        public string[][] OutgoingBytes { get; set; }
    }

    public struct BandwidthResult
    {
        public BandWidth BandWidth { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }

    public class V6Networks
    {
        public string V6Network { get; set; }
        public string V6MainIP { get; set; }
        public string V6NetworkSize { get; set; }
    }

    public struct ServerResult
    {
        public Dictionary<string, Server> Servers { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }
}