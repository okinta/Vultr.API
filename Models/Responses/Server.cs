using System.Collections.Generic;
using System.Net.Http;

namespace Vultr.API.Models.Responses
{
    public class Server
    {
        public string SUBID { get; set; }
        public string os { get; set; }
        public string ram { get; set; }
        public string disk { get; set; }
        public string main_ip { get; set; }
        public string vcpu_count { get; set; }
        public string location { get; set; }
        public string DCID { get; set; }
        public string default_password { get; set; }
        public string date_created { get; set; }
        public string pending_charges { get; set; }
        public string status { get; set; }
        public string cost_per_month { get; set; }
        public double current_bandwidth_gb { get; set; }
        public string allowed_bandwidth_gb { get; set; }
        public string netmask_v4 { get; set; }
        public string gateway_v4 { get; set; }
        public string power_status { get; set; }
        public string server_state { get; set; }
        public string VPSPLANID { get; set; }
        public string v6_main_ip { get; set; }
        public string v6_network_size { get; set; }
        public string v6_network { get; set; }
        public V6Networks[] v6_networks { get; set; }
        public string label { get; set; }
        public string internal_ip { get; set; }
        public string kvm_url { get; set; }
        public string auto_backups { get; set; }
        public string tag { get; set; }
        public string OSID { get; set; }
        public string APPID { get; set; }
        public string FIREWALLGROUPID { get; set; }
    }

    public class CreateServer
    {
        public string SUBID { get; set; }
    }

    public class BandWidth
    {
        public string[][] incoming_bytes { get; set; }
        public string[][] outgoing_bytes { get; set; }
    }

    public struct BandwidthResult
    {
        public BandWidth BandWidth { get; set; }
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public class V6Networks
    {
        public string v6_network { get; set; }
        public string v6_main_ip { get; set; }
        public string v6_network_size { get; set; }
    }

    public struct ServerResult
    {
        public Dictionary<string, Server> Servers { get; set; }
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public struct CreateServerResult
    {
        public CreateServer Server { get; set; }
        public HttpResponseMessage ApiResponse { get; set; }
    }
}
