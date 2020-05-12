using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Vultr.API.Models.Responses;

namespace Vultr.API.Clients
{
    public class FirewallClient
    {
        private readonly string _ApiKey;

        public FirewallClient(string ApiKey)
        {
            _ApiKey = ApiKey;
        }

        /// <summary>
        /// List all firewall groups on the current account.
        /// </summary>
        /// <returns>List of all firewall groups on the current account.</returns>
        public FirewallGroupResult GetFirewallGroups()
        {
            var answer = new Dictionary<string, FirewallGroup>();
            var httpResponse = Extensions.ApiClient.ApiExecute("firewall/group_list", _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
                answer = JsonConvert.DeserializeObject<Dictionary<string, FirewallGroup>>((st ?? "") == "[]" ? "{}" : st);
            }

            return new FirewallGroupResult() { ApiResponse = httpResponse, FirewallGroups = answer };
        }

        /// <summary>
        /// Create a new firewall group on the current account.
        /// </summary>
        /// <param name="description">Description of firewall group.</param>
        /// <returns>FirewallGroup element with only FIREWALLGROUPID.</returns>
        public FirewallGroupCreateResult CreateFirewallGroup(string description)
        {
            var dict = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("description", description)
            };
            var answer = new FirewallGroup();
            var httpResponse = Extensions.ApiClient.ApiExecute("firewall/group_create", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
                answer = JsonConvert.DeserializeObject<FirewallGroup>((st ?? "") == "[]" ? "{}" : st);
            }

            return new FirewallGroupCreateResult() { ApiResponse = httpResponse, FirewallGroup = answer };
        }

        /// <summary>
        /// Delete a firewall group. Use this function with caution because the firewall group being deleted will be detached from all servers. This can result in open ports accessible to the internet.
        /// </summary>
        /// <param name="FIREWALLGROUPID">Unique identifier for Firewall group to delete. These can be found Using the GetFirewallGroups()</param>
        /// <returns>No response, check HTTP result code.</returns>
        public FirewallGroupDeleteResult DeleteFirewallGroup(string FIREWALLGROUPID)
        {
            var dict = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("FIREWALLGROUPID", FIREWALLGROUPID)
            };
            var httpResponse = Extensions.ApiClient.ApiExecute("firewall/group_delete", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
            }

            return new FirewallGroupDeleteResult() { ApiResponse = httpResponse };
        }

        /// <summary>
        /// Update firewall group on the current account.
        /// </summary>
        /// <param name="description">Description of firewall group.</param>
        /// <param name="FIREWALLGROUPID">Unique identifier for Firewall group to delete. These can be found Using the GetFirewallGroups()</param>
        /// <returns>No response, check HTTP result code.</returns>
        public FirewallGroupUpdateResult UpdateFirewallGroup(string description, string FIREWALLGROUPID)
        {
            var dict = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("description", description),
                new KeyValuePair<string, object>("FIREWALLGROUPID", FIREWALLGROUPID)
            };
            var answer = new FirewallGroup();
            var httpResponse = Extensions.ApiClient.ApiExecute("firewall/group_set_description", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
            }

            return new FirewallGroupUpdateResult() { ApiResponse = httpResponse };
        }

        /// <summary>
        /// List the rules in a firewall group.
        /// </summary>
        /// <param name="FIREWALLGROUPID">Target firewall group. See GetFirewallGroups()</param>
        /// <param name="ip_type">IP address type. Possible values: "IPV4", "IPV6"</param>
        /// <param name="direction">Direction of rule.</param>
        /// <returns>List of all firewall roles on the current account.</returns>
        public FirewallRuleResult GetFirewallRules(string FIREWALLGROUPID, IPTYPE ip_type, FirewallDirection direction)
        {
            if (Information.IsNothing(ip_type))
            {
                ip_type = IPTYPE.IPV4;
            }

            var answer = new Dictionary<string, FirewallRule>();
            var httpResponse = Extensions.ApiClient.ApiExecute("firewall/rule_list?FIREWALLGROUPID=" + FIREWALLGROUPID + "&direction=" + direction + "&ip_type=" + ip_type.ToString(), _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
                answer = JsonConvert.DeserializeObject<Dictionary<string, FirewallRule>>((st ?? "") == "[]" ? "{}" : st);
            }

            return new FirewallRuleResult() { ApiResponse = httpResponse, FirewallRules = answer };
        }

        /// <summary>
        /// Create a rule in a firewall group.
        /// </summary>
        /// <param name="FirewallRule">New FirewallRule object.</param>
        /// <returns>FirewallGroup element with only FIREWALLGROUPID.</returns>
        public FirewallRuleCreateResult CreateFirewallRule(string FIREWALLGROUPID, FirewallRule FirewallRule, FirewallDirection FirewallDirection)
        {
            var dict = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("FIREWALLGROUPID", FIREWALLGROUPID),
                new KeyValuePair<string, object>("direction", FirewallDirection.ToString()),
                new KeyValuePair<string, object>("action", FirewallRule.Action),
                new KeyValuePair<string, object>("port", FirewallRule.Port),
                new KeyValuePair<string, object>("protocol", FirewallRule.Protocol),
                new KeyValuePair<string, object>("subnet", FirewallRule.Subnet),
                new KeyValuePair<string, object>("subnet_size", FirewallRule.SubnetSize)
            };
            var answer = new FirewallRule();
            var httpResponse = Extensions.ApiClient.ApiExecute("firewall/rule_create", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
                answer = JsonConvert.DeserializeObject<FirewallRule>((st ?? "") == "[]" ? "{}" : st);
            }

            return new FirewallRuleCreateResult() { ApiResponse = httpResponse, FirewallRule = answer };
        }

        /// <summary>
        /// Delete a rule in a firewall group.
        /// </summary>
        /// <param name="FIREWALLGROUPID">Unique identifier for Firewall group to delete. These can be found Using the GetFirewallGroups()</param>
        /// <param name="rulenumber">Unique identifier for Firewall rule to delete. These can be found Using the GetFirewallRules()</param>
        /// <returns>No response, check HTTP result code.</returns>
        public FirewallRuleDeleteResult DeleteFirewallRule(string FIREWALLGROUPID, int rulenumber)
        {
            var dict = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("FIREWALLGROUPID", FIREWALLGROUPID),
                new KeyValuePair<string, object>("rulenumber", rulenumber)
            };
            var httpResponse = Extensions.ApiClient.ApiExecute("firewall/rule_delete", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
            }

            return new FirewallRuleDeleteResult() { ApiResponse = httpResponse };
        }
    }
}