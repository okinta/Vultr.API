using System.Collections.Generic;
using System.Net.Http;

namespace Vultr.API.Models
{
    public class FirewallRule
    {
        public int rulenumber { get; set; }
        public string action { get; set; }
        public string protocol { get; set; }
        public string port { get; set; }
        public string subnet { get; set; }
        public int subnet_size { get; set; }
        public string source { get; set; }
        public string notes { get; set; }
    }

    public class FirewallGroup
    {
        public string FIREWALLGROUPID { get; set; }
        public string description { get; set; }
        public string date_created { get; set; }
        public string date_modified { get; set; }
        public int instance_count { get; set; }
        public int rule_count { get; set; }
        public int max_rule_count { get; set; }
    }

    public struct FirewallRuleResult
    {
        public Dictionary<string, FirewallRule> FirewallRules { get; set; }
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public struct FirewallGroupResult
    {
        public Dictionary<string, FirewallGroup> FirewallGroups { get; set; }
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public struct FirewallRuleCreateResult
    {
        public FirewallRule FirewallRule { get; set; }
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public struct FirewallRuleDeleteResult
    {
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public struct FirewallRuleUpdateResult
    {
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public struct FirewallGroupCreateResult
    {
        public FirewallGroup FirewallGroup { get; set; }
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public struct FirewallGroupDeleteResult
    {
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public struct FirewallGroupUpdateResult
    {
        public HttpResponseMessage ApiResponse { get; set; }
    }
}
