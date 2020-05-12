using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Vultr.API.Models.Responses
{
    public class Domain
    {
        public string domain { get; set; }
        public string date_created { get; set; }
    }

    public class Record
    {
        public string type { get; set; }
        public string name { get; set; }
        public string data { get; set; }
        public int priority { get; set; }
        public int RECORDID { get; set; }
        public int ttl { get; set; }
    }

    public class SOARecord
    {
        public string nsprimary { get; set; }
        public string email { get; set; }
    }

    public struct RecordResult
    {
        public List<Record> Records { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct DomainResult
    {
        public List<Domain> Domains { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct DomainCreateResult
    {
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct DomainUpdateResult
    {
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct SOAInfoResult
    {
        public SOARecord Record { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct DomainDeleteResult
    {
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct RecordDeleteResult
    {
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct DNSSECKeyResult
    {
        public JArray DNSSECKeys { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }
}