using System.Collections.Generic;
using System.Net;

namespace Vultr.API.Models.Responses
{
    public class FirewallRule
    {
        public int rulenumber { get; set; }
        public string action { get; set; }
        public string protocol { get; set; }
        public string port { get; set; }
        public string subnet { get; set; }
        public int subnet_size { get; set; }
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
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct FirewallGroupResult
    {
        public Dictionary<string, FirewallGroup> FirewallGroups { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct FirewallRuleCreateResult
    {
        public FirewallRule FirewallRule { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct FirewallRuleDeleteResult
    {
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct FirewallRuleUpdateResult
    {
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct FirewallGroupCreateResult
    {
        public FirewallGroup FirewallGroup { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct FirewallGroupDeleteResult
    {
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct FirewallGroupUpdateResult
    {
        public HttpWebResponse ApiResponse { get; set; }
    }

    public class IPTYPE
    {
        private string Key;
        public static readonly IPTYPE IPV4 = new IPTYPE("v4");
        public static readonly IPTYPE IPV6 = new IPTYPE("v6");

        private IPTYPE(string key)
        {
            Key = key;
        }

        public override string ToString()
        {
            return Key;
        }
    }

    public class FirewallDirection
    {
        private string Key;
        public static readonly FirewallDirection DIRECTIONIN = new FirewallDirection("in");
        public static readonly FirewallDirection DIRECTIONOUT = new FirewallDirection("out");

        private FirewallDirection(string key)
        {
            Key = key;
        }

        public override string ToString()
        {
            return Key;
        }
    }
}