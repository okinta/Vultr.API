using System.Collections.Generic;
using System.Net;

namespace Vultr.API.Models.Responses
{
    public class OperatingSystem
    {
        public string OSID { get; set; }
        public string Name { get; set; }
        public string Arch { get; set; }
        public string Family { get; set; }
        public bool Windows { get; set; }
    }

    public struct OperatingSystemResult
    {
        public Dictionary<int, OperatingSystem> OperatingSystems { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }
}