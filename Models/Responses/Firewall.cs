using System.Collections.Generic;
using System.Net;

namespace Vultr.API.Models.Responses
{
    public class FirewallRule
    {
        public int RuleNumber { get; set; }
        public string Action { get; set; }
        public string Protocol { get; set; }
        public string Port { get; set; }
        public string Subnet { get; set; }
        public int SubnetSize { get; set; }
    }

    public class FirewallGroup
    {
        public string FirewallGroupID { get; set; }
        public string Description { get; set; }
        public string DateCreated { get; set; }
        public string DateModified { get; set; }
        public int InstanceCount { get; set; }
        public int RuleCount { get; set; }
        public int MaxRuleCount { get; set; }
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
        private readonly string Key;
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
        private readonly string Key;
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