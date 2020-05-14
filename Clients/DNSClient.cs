using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json.Linq;
using Vultr.API.Extensions;
using Vultr.API.Models;

namespace Vultr.API.Clients
{
    public class DNSClient
    {
        private string ApiKey { get; }

        public DNSClient(string apiKey)
        {
            ApiKey = apiKey;
        }

        /// <summary>
        /// List all domains associated with the current account.
        /// </summary>
        /// <returns>List of all domains associated with the current account.</returns>
        public DomainResult GetDomains()
        {
            var response = ApiClient.ApiExecute<List<Domain>>(
                "dns/list", ApiKey);
            return new DomainResult()
            {
                ApiResponse = response.Item1,
                Domains = response.Item2
            };
        }

        /// <summary>
        /// List all the records associated with a particular domain.
        /// </summary>
        /// <param name="domain">Domain to list records for</param>
        /// <returns>List of all records associated with the current domain.</returns>
        public RecordResult GetDomainRecords(string domain)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("domain", domain)
            };

            var response = ApiClient.ApiExecute<List<Record>>(
                "dns/records", ApiKey, args);
            return new RecordResult()
            {
                ApiResponse = response.Item1,
                Records = response.Item2
            };
        }

        /// <summary>
        /// Create a domain name in DNS.
        /// </summary>
        /// <param name="domain">Domain name to create</param>
        /// <param name="serverip">Server IP to use when creating default records (A and MX)</param>
        /// <returns>No response, check HTTP result code.</returns>
        public DomainCreateResult CreateDomain(string domain, IPAddress serverip)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("domain", domain),
                new KeyValuePair<string, object>("serverip", serverip.ToString())
            };

            var response = ApiClient.ApiExecute<Domain>(
                "dns/create_domain", ApiKey, args, ApiMethod.POST);
            return new DomainCreateResult()
            {
                ApiResponse = response.Item1
            };
        }

        /// <summary>
        /// Add a DNS record.
        /// </summary>
        /// <param name="domain">Domain name to add record to</param>
        /// <param name="Record">Details of a record</param>
        /// <returns>No response, check HTTP result code.</returns>
        public DomainCreateResult CreateDomain(Record Record, string domain)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("domain", domain),
                new KeyValuePair<string, object>("data", Record.data),
                new KeyValuePair<string, object>("name", Record.name),
                new KeyValuePair<string, object>("type", Record.type),
                new KeyValuePair<string, object>("ttl", Record.ttl),
                new KeyValuePair<string, object>("priority", Record.priority)
            };

            var response = ApiClient.ApiExecute<Record>(
                "dns/create_record", ApiKey, args, ApiMethod.POST);
            return new DomainCreateResult()
            {
                ApiResponse = response.Item1
            };
        }

        /// <summary>
        /// Delete a domain name and all associated records.
        /// </summary>
        /// <param name="domain">Domain name to delete</param>
        /// <returns>No response, check HTTP result code.</returns>
        public DomainDeleteResult DeleteDomain(string domain)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("domain", domain)
            };

            var response = ApiClient.ApiExecute<Domain>(
                "dns/delete_domain", ApiKey, args, ApiMethod.POST);
            return new DomainDeleteResult()
            {
                ApiResponse = response.Item1
            };
        }

        /// <summary>
        /// Delete an individual DNS record.
        /// </summary>
        /// <param name="domain">Domain name to delete record from</param>
        /// <param name="RECORDID">ID of record to delete. See GetDomainRecords()</param>
        /// <returns>No response, check HTTP result code.</returns>
        public RecordDeleteResult DeleteRecord(string domain, int RECORDID)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("domain", domain),
                new KeyValuePair<string, object>("RECORDID", RECORDID)
            };

            var response = ApiClient.ApiExecute<Record>(
                "dns/delete_record", ApiKey, args, ApiMethod.POST);
            return new RecordDeleteResult()
            {
                ApiResponse = response.Item1
            };
        }

        /// <summary>
        /// Enable DNSSEC for a domain.
        /// </summary>
        /// <param name="domain">Domain name to update record. DNSSEC will be enabled for the given domain</param>
        /// <returns>No response, check HTTP result code.</returns>
        public DomainUpdateResult DNSSECEnable(string domain)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("domain", domain),
                new KeyValuePair<string, object>("enable", "yes")
            };

            var response = ApiClient.ApiExecute<Domain>(
                "dns/dnssec_enable", ApiKey, args, ApiMethod.POST);
            return new DomainUpdateResult()
            {
                ApiResponse = response.Item1
            };
        }

        /// <summary>
        /// Get the DNSSEC keys (if enabled) for a domain.
        /// </summary>
        /// <param name="domain">Domain from which to gather DNSSEC keys.</param>
        /// <returns>DNSSEC keys</returns>
        public DNSSECKeyResult DNSSECInfo(string domain)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("domain", domain)
            };

            var response = ApiClient.ApiExecute<JArray>(
                "dns/dnssec_info", ApiKey, args);
            return new DNSSECKeyResult()
            {
                ApiResponse = response.Item1,
                DNSSECKeys = response.Item2
            };
        }

        /// <summary>
        /// Get the SOA record information for a domain.
        /// </summary>
        /// <param name="domain">Domain from which to gather SOA information</param>
        /// <returns>SOA Record</returns>
        public SOAInfoResult SOAInfo(string domain)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("domain", domain)
            };

            var response = ApiClient.ApiExecute<SOARecord>(
                "dns/soa_info", ApiKey, args);
            return new SOAInfoResult()
            {
                ApiResponse = response.Item1,
                Record = response.Item2
            };
        }

        /// <summary>
        /// Update the SOA record information for a domain.
        /// </summary>
        /// <param name="domain">Domain name to update record</param>
        /// <param name="SOARecord">SOA record</param>
        /// <returns>No response, check HTTP result code.</returns>
        public DomainUpdateResult SOAUpdate(string domain, SOARecord SOARecord)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("domain", domain),
                new KeyValuePair<string, object>("nsprimary", SOARecord.nsprimary),
                new KeyValuePair<string, object>("email", SOARecord.email)
            };

            var response = ApiClient.ApiExecute<Record>(
                "dns/soa_update", ApiKey, args, ApiMethod.POST);
            return new DomainUpdateResult()
            {
                ApiResponse = response.Item1
            };
        }


        /// <summary>
        /// Update the SOA record information for a domain.
        /// </summary>
        /// <param name="domain">Domain name to update record</param>
        /// <param name="Record">DNS record</param>
        /// <returns>No response, check HTTP result code.</returns>
        public DomainUpdateResult UpdateRecord(string domain, Record Record)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("domain", domain),
                new KeyValuePair<string, object>("RECORDID", Record.RECORDID),
                new KeyValuePair<string, object>("name", Record.name),
                new KeyValuePair<string, object>("data", Record.data),
                new KeyValuePair<string, object>("ttl", Record.ttl),
                new KeyValuePair<string, object>("priority", Record.priority)
            };

            var response = ApiClient.ApiExecute<Record>(
                "dns/update_record", ApiKey, args, ApiMethod.POST);
            return new DomainUpdateResult()
            {
                ApiResponse = response.Item1
            };
        }
    }
}
