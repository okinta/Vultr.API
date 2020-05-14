using System.Collections.Generic;
using System.Net.Http;

namespace Vultr.API.Models.Responses
{
    public class OperatingSystem
    {
        public string OSID { get; set; }
        public string name { get; set; }
        public string arch { get; set; }
        public string family { get; set; }
        public bool windows { get; set; }
    }

    public struct OperatingSystemResult
    {
        public Dictionary<int, OperatingSystem> OperatingSystems { get; set; }
        public HttpResponseMessage ApiResponse { get; set; }
    }
}
