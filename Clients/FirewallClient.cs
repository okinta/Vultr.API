using System.Collections.Generic;
using Vultr.API.Models;
using Vultr.Clients;

namespace Vultr.API.Clients
{
    public class FirewallClient : BaseClient
    {
        public FirewallClient(string apiKey, string apiURL) : base(apiKey, apiURL) { }

        /// <summary>
        /// List all firewall groups on the current account.
        /// </summary>
        /// <returns>List of all firewall groups on the current account.</returns>
        public FirewallGroupResult GetFirewallGroups()
        {
            var response = ApiExecute<
                Dictionary<string, FirewallGroup>>("firewall/group_list", ApiKey);
            return new FirewallGroupResult()
            {
                ApiResponse = response.Item1,
                FirewallGroups = response.Item2
            };
        }

        /// <summary>
        /// Create a new firewall group on the current account.
        /// </summary>
        /// <param name="description">Description of firewall group.</param>
        /// <returns>FirewallGroup element with only FIREWALLGROUPID.</returns>
        public FirewallGroupCreateResult CreateFirewallGroup(string description)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("description", description)
            };

            var response = ApiExecute<FirewallGroup>(
                "firewall/group_create", ApiKey, args, ApiMethod.POST);
            return new FirewallGroupCreateResult()
            {
                ApiResponse = response.Item1,
                FirewallGroup = response.Item2
            };
        }

        /// <summary>
        /// Delete a firewall group. Use this function with caution because the firewall group being deleted will be detached from all servers. This can result in open ports accessible to the internet.
        /// </summary>
        /// <param name="FIREWALLGROUPID">Unique identifier for Firewall group to delete. These can be found Using the GetFirewallGroups()</param>
        /// <returns>No response, check HTTP result code.</returns>
        public FirewallGroupDeleteResult DeleteFirewallGroup(string FIREWALLGROUPID)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("FIREWALLGROUPID", FIREWALLGROUPID)
            };

            var response = ApiExecute<FirewallGroup>(
                "firewall/group_delete", ApiKey, args, ApiMethod.POST);
            return new FirewallGroupDeleteResult()
            {
                ApiResponse = response.Item1
            };
        }

        /// <summary>
        /// Update firewall group on the current account.
        /// </summary>
        /// <param name="description">Description of firewall group.</param>
        /// <param name="FIREWALLGROUPID">Unique identifier for Firewall group to delete. These can be found Using the GetFirewallGroups()</param>
        /// <returns>No response, check HTTP result code.</returns>
        public FirewallGroupUpdateResult UpdateFirewallGroup(string description, string FIREWALLGROUPID)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("description", description),
                new KeyValuePair<string, object>("FIREWALLGROUPID", FIREWALLGROUPID)
            };

            var response = ApiExecute<FirewallGroup>(
                "firewall/group_set_description", ApiKey, args, ApiMethod.POST);
            return new FirewallGroupUpdateResult()
            {
                ApiResponse = response.Item1
            };
        }

        /// <summary>
        /// List the rules in a firewall group.
        /// </summary>
        /// <param name="FIREWALLGROUPID">Target firewall group. See
        /// /v1/firewall/group_list.</param>
        /// <param name="direction">Direction of firewall rules. Possible values:
        /// "in".</param>
        /// <param name="ip_type">IP address type. Possible values: "v4", "v6".</param>
        /// <returns>The list of firewall rules.</returns>
        public FirewallRuleResult GetFirewallRules(
            string FIREWALLGROUPID,
            string direction = "in",
            string ip_type = null)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("FIREWALLGROUPID", FIREWALLGROUPID),
                new KeyValuePair<string, object>("direction", direction),
                new KeyValuePair<string, object>("ip_type", ip_type),
            };

            var response = ApiExecute<
                Dictionary<string, FirewallRule>>("firewall/rule_list", ApiKey, args);
            return new FirewallRuleResult()
            {
                ApiResponse = response.Item1,
                FirewallRules = response.Item2
            };
        }

        /// <summary>
        /// Create a rule in a firewall group.
        /// </summary>
        /// <param name="FIREWALLGROUPID">Target firewall group. See
        /// /v1/firewall/group_list.</param>
        /// <param name="direction">Direction of rule. Possible values: "in".</param>
        /// <param name="ip_type">IP address type. Possible values: "v4", "v6".</param>
        /// <param name="protocol">Protocol type. Possible values: "icmp", "tcp",
        /// "udp", "gre".</param>
        /// <param name="subnet">IP address representing a subnet. The IP address
        /// format must match with the "ip_type" parameter value.</param>
        /// <param name="subnet_size">IP prefix size in bits.</param>
        /// <param name="port">Optional. TCP/UDP only. This field can be an integer
        /// value specifying a port or a colon separated port range.</param>
        /// <param name="notes">Optional. This field supports notes up to 255
        /// characters.</param>
        /// <param name="source">Optional. If the source string is given a value of
        /// "cloudflare" subnet and subnet_size will both be ignored, this will allow
        /// all of Cloudflare's IP space through the firewall. Possible values: "",
        /// "cloudflare".</param>
        /// <returns>The newly created rule.</returns>
        public FirewallRuleCreateResult CreateFirewallRule(
            string FIREWALLGROUPID,
            string direction = "in",
            string ip_type = null,
            string protocol = null,
            string subnet = null,
            int? subnet_size = null,
            string port = null,
            string notes = null,
            string source = null)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("FIREWALLGROUPID", FIREWALLGROUPID),
                new KeyValuePair<string, object>("direction", direction),
                new KeyValuePair<string, object>("ip_type", ip_type),
                new KeyValuePair<string, object>("protocol", protocol),
                new KeyValuePair<string, object>("subnet", subnet),
                new KeyValuePair<string, object>("subnet_size", subnet_size),
                new KeyValuePair<string, object>("port", port),
                new KeyValuePair<string, object>("notes", notes),
                new KeyValuePair<string, object>("source", source)
            };

            var response = ApiExecute<FirewallRule>(
                "firewall/rule_create", ApiKey, args, ApiMethod.POST);
            return new FirewallRuleCreateResult()
            {
                ApiResponse = response.Item1,
                FirewallRule = response.Item2
            };
        }

        /// <summary>
        /// Delete a rule in a firewall group.
        /// </summary>
        /// <param name="FIREWALLGROUPID">Unique identifier for Firewall group to delete. These can be found Using the GetFirewallGroups()</param>
        /// <param name="rulenumber">Unique identifier for Firewall rule to delete. These can be found Using the GetFirewallRules()</param>
        /// <returns>No response, check HTTP result code.</returns>
        public FirewallRuleDeleteResult DeleteFirewallRule(
            string FIREWALLGROUPID, int rulenumber)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("FIREWALLGROUPID", FIREWALLGROUPID),
                new KeyValuePair<string, object>("rulenumber", rulenumber)
            };

            var response = ApiExecute<FirewallRule>(
                "firewall/rule_delete", ApiKey, args, ApiMethod.POST);
            return new FirewallRuleDeleteResult()
            {
                ApiResponse = response.Item1
            };
        }
    }
}
