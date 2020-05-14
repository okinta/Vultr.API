using System.Collections.Generic;
using Vultr.API.Extensions;
using Vultr.API.Models;

namespace Vultr.API.Clients
{
    public class FirewallClient
    {
        private string ApiKey { get; }

        public FirewallClient(string apiKey)
        {
            ApiKey = apiKey;
        }

        /// <summary>
        /// List all firewall groups on the current account.
        /// </summary>
        /// <returns>List of all firewall groups on the current account.</returns>
        public FirewallGroupResult GetFirewallGroups()
        {
            var response = ApiClient.ApiExecute<
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

            var response = ApiClient.ApiExecute<FirewallGroup>(
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

            var response = ApiClient.ApiExecute<FirewallGroup>(
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

            var response = ApiClient.ApiExecute<FirewallGroup>(
                "firewall/group_set_description", ApiKey, args, ApiMethod.POST);
            return new FirewallGroupUpdateResult()
            {
                ApiResponse = response.Item1
            };
        }

        /// <summary>
        /// List the rules in a firewall group.
        /// </summary>
        /// <param name="FIREWALLGROUPID">Target firewall group. See GetFirewallGroups()</param>
        /// <param name="ip_type">IP address type. Possible values: "IPV4", "IPV6"</param>
        /// <param name="direction">Direction of rule.</param>
        /// <returns>List of all firewall roles on the current account.</returns>
        public FirewallRuleResult GetFirewallRules(
            string FIREWALLGROUPID, IPTYPE ip_type = IPTYPE.V4,
            FirewallDirection direction = FirewallDirection.In)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("FIREWALLGROUPID", FIREWALLGROUPID),
                new KeyValuePair<string, object>("direction", direction),
                new KeyValuePair<string, object>("ip_type", ip_type),
            };

            var response = ApiClient.ApiExecute<
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
        /// <param name="FirewallRule">New FirewallRule object.</param>
        /// <returns>FirewallGroup element with only FIREWALLGROUPID.</returns>
        public FirewallRuleCreateResult CreateFirewallRule(string FIREWALLGROUPID, FirewallRule FirewallRule, FirewallDirection FirewallDirection = FirewallDirection.In)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("FIREWALLGROUPID", FIREWALLGROUPID),
                new KeyValuePair<string, object>("direction", FirewallDirection.ToString()),
                new KeyValuePair<string, object>("action", FirewallRule.action),
                new KeyValuePair<string, object>("port", FirewallRule.port),
                new KeyValuePair<string, object>("protocol", FirewallRule.protocol),
                new KeyValuePair<string, object>("subnet", FirewallRule.subnet),
                new KeyValuePair<string, object>("subnet_size", FirewallRule.subnet_size)
            };

            var response = ApiClient.ApiExecute<FirewallRule>(
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

            var response = ApiClient.ApiExecute<FirewallRule>(
                "firewall/rule_delete", ApiKey, args, ApiMethod.POST);
            return new FirewallRuleDeleteResult()
            {
                ApiResponse = response.Item1
            };
        }
    }
}
