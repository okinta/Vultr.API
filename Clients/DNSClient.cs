using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Vultr.API.Models.Responses;

namespace Vultr.API.Clients
{
    public class DNSClient
    {
        private readonly string _ApiKey;

        public DNSClient(string ApiKey)
        {
            _ApiKey = ApiKey;
        }

        /// <summary>
        /// List all domains associated with the current account.
        /// </summary>
        /// <returns>List of all domains associated with the current account.</returns>
        public DomainResult GetDomains()
        {
            var answer = new List<Domain>();
            var httpResponse = Extensions.ApiClient.ApiExecute("dns/list", _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                    answer = JsonConvert.DeserializeObject<List<Domain>>((st ?? "") == "[]" ? "{}" : st);
                }
            }

            return new DomainResult() { ApiResponse = httpResponse, Domains = answer };
        }

        /// <summary>
        /// List all the records associated with a particular domain.
        /// </summary>
        /// <param name="domain">Domain to list records for</param>
        /// <returns>List of all records associated with the current domain.</returns>
        public RecordResult GetDomainRecords(string domain)
        {
            var answer = new List<Record>();
            var httpResponse = Extensions.ApiClient.ApiExecute("dns/records?domain=" + domain, _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                    answer = JsonConvert.DeserializeObject<List<Record>>((st ?? "") == "[]" ? "{}" : st);
                }
            }

            return new RecordResult() { ApiResponse = httpResponse, Records = answer };
        }

        /// <summary>
        /// Create a domain name in DNS.
        /// </summary>
        /// <param name="domain">Domain name to create</param>
        /// <param name="serverip">Server IP to use when creating default records (A and MX)</param>
        /// <returns>No response, check HTTP result code.</returns>
        public DomainCreateResult CreateDomain(string domain, IPAddress serverip)
        {
            var dict = new List<KeyValuePair<string, object>>();
            dict.Add(new KeyValuePair<string, object>("domain", domain));
            dict.Add(new KeyValuePair<string, object>("serverip", serverip.ToString()));
            var httpResponse = Extensions.ApiClient.ApiExecute("dns/create_domain", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                }
            }

            return new DomainCreateResult() { ApiResponse = httpResponse };
        }

        /// <summary>
        /// Add a DNS record.
        /// </summary>
        /// <param name="domain">Domain name to add record to</param>
        /// <param name="Record">Details of a record</param>
        /// <returns>No response, check HTTP result code.</returns>
        public DomainCreateResult CreateDomain(Record Record, string domain)
        {
            var dict = new List<KeyValuePair<string, object>>();
            dict.Add(new KeyValuePair<string, object>("domain", domain));
            dict.Add(new KeyValuePair<string, object>("data", Record.data));
            dict.Add(new KeyValuePair<string, object>("name", Record.name));
            dict.Add(new KeyValuePair<string, object>("type", Record.type));
            dict.Add(new KeyValuePair<string, object>("ttl", Record.ttl));
            dict.Add(new KeyValuePair<string, object>("priority", Record.priority));
            var httpResponse = Extensions.ApiClient.ApiExecute("dns/create_record", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                }
            }

            return new DomainCreateResult() { ApiResponse = httpResponse };
        }

        /// <summary>
        /// Delete a domain name and all associated records.
        /// </summary>
        /// <param name="domain">Domain name to delete</param>
        /// <returns>No response, check HTTP result code.</returns>
        public DomainDeleteResult DeleteDomain(string domain)
        {
            var dict = new List<KeyValuePair<string, object>>();
            dict.Add(new KeyValuePair<string, object>("domain", domain));
            var httpResponse = Extensions.ApiClient.ApiExecute("dns/delete_domain", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                }
            }

            return new DomainDeleteResult() { ApiResponse = httpResponse };
        }

        /// <summary>
        /// Delete an individual DNS record.
        /// </summary>
        /// <param name="domain">Domain name to delete record from</param>
        /// <param name="RECORDID">ID of record to delete. See GetDomainRecords()</param>
        /// <returns>No response, check HTTP result code.</returns>
        public RecordDeleteResult DeleteRecord(string domain, int RECORDID)
        {
            var dict = new List<KeyValuePair<string, object>>();
            dict.Add(new KeyValuePair<string, object>("domain", domain));
            dict.Add(new KeyValuePair<string, object>("RECORDID", RECORDID));
            var httpResponse = Extensions.ApiClient.ApiExecute("dns/delete_record", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                }
            }

            return new RecordDeleteResult() { ApiResponse = httpResponse };
        }

        /// <summary>
        /// Enable DNSSEC for a domain.
        /// </summary>
        /// <param name="domain">Domain name to update record. DNSSEC will be enabled for the given domain</param>
        /// <returns>No response, check HTTP result code.</returns>
        public DomainUpdateResult DNSSECEnable(string domain)
        {
            var dict = new List<KeyValuePair<string, object>>();
            dict.Add(new KeyValuePair<string, object>("domain", domain));
            dict.Add(new KeyValuePair<string, object>("enable", "yes"));
            var httpResponse = Extensions.ApiClient.ApiExecute("dns/dnssec_enable", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                }
            }

            return new DomainUpdateResult() { ApiResponse = httpResponse };
        }

        /// <summary>
        /// Get the DNSSEC keys (if enabled) for a domain.
        /// </summary>
        /// <param name="domain">Domain from which to gather DNSSEC keys.</param>
        /// <returns>DNSSEC keys</returns>
        public DNSSECKeyResult DNSSECInfo(string domain)
        {
            var answer = new JArray();
            var httpResponse = Extensions.ApiClient.ApiExecute("dns/dnssec_info?domain=" + domain, _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                    answer = JArray.Parse(st);
                }
            }

            return new DNSSECKeyResult() { ApiResponse = httpResponse, DNSSECKeys = answer };
        }

        /// <summary>
        /// Get the SOA record information for a domain.
        /// </summary>
        /// <param name="domain">Domain from which to gather SOA information</param>
        /// <returns>SOA Record</returns>
        public SOAInfoResult SOAInfo(string domain)
        {
            var answer = new SOARecord();
            var httpResponse = Extensions.ApiClient.ApiExecute("dns/soa_info?domain=" + domain, _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                    answer = JsonConvert.DeserializeObject<SOARecord>((st ?? "") == "[]" ? "{}" : st);
                }
            }

            return new SOAInfoResult() { ApiResponse = httpResponse, Record = answer };
        }

        /// <summary>
        /// Update the SOA record information for a domain.
        /// </summary>
        /// <param name="domain">Domain name to update record</param>
        /// <param name="SOARecord">SOA record</param>
        /// <returns>No response, check HTTP result code.</returns>
        public DomainUpdateResult SOAUpdate(string domain, SOARecord SOARecord)
        {
            var dict = new List<KeyValuePair<string, object>>();
            dict.Add(new KeyValuePair<string, object>("domain", domain));
            dict.Add(new KeyValuePair<string, object>("nsprimary", SOARecord.nsprimary));
            dict.Add(new KeyValuePair<string, object>("email", SOARecord.email));
            var httpResponse = Extensions.ApiClient.ApiExecute("dns/soa_update", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                }
            }

            return new DomainUpdateResult() { ApiResponse = httpResponse };
        }


        /// <summary>
        /// Update the SOA record information for a domain.
        /// </summary>
        /// <param name="domain">Domain name to update record</param>
        /// <param name="Record">DNS record</param>
        /// <returns>No response, check HTTP result code.</returns>
        public DomainUpdateResult UpdateRecord(string domain, Record Record)
        {
            var dict = new List<KeyValuePair<string, object>>();
            dict.Add(new KeyValuePair<string, object>("domain", domain));
            dict.Add(new KeyValuePair<string, object>("RECORDID", Record.RECORDID));
            dict.Add(new KeyValuePair<string, object>("name", Record.name));
            dict.Add(new KeyValuePair<string, object>("data", Record.data));
            dict.Add(new KeyValuePair<string, object>("ttl", Record.ttl));
            dict.Add(new KeyValuePair<string, object>("priority", Record.priority));
            var httpResponse = Extensions.ApiClient.ApiExecute("dns/update_record", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                }
            }

            return new DomainUpdateResult() { ApiResponse = httpResponse };
        }
    }
}