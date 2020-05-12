using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;

namespace Vultr.API.Models.Responses
{
    public class Domain
    {
        public string Name { get; set; }
        public string DateCreated { get; set; }
    }

    public class Record
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public int Priority { get; set; }
        public int ID { get; set; }
        public int TTL { get; set; }
    }

    public class SOARecord
    {
        public string NSPrimary { get; set; }
        public string Email { get; set; }
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