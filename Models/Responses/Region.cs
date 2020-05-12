using System.Collections.Generic;
using System.Net;

namespace Vultr.API.Models.Responses
{
    public class Region
    {
        public string DCID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Continent { get; set; }
        public string State { get; set; }
        public bool DDOSProtection { get; set; }
        public bool BlockStorage { get; set; }
        public string RegionCode { get; set; }
        public int[] Availability { get; set; }
    }

    public struct RegionResult
    {
        public Dictionary<int, Region> Regions { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }

    public class PlanIdsClass
    {
        public static int[] PlanIds { get; set; }
    }

    public struct RegionAvailabilityResult
    {
        public PlanIdsClass PlanIds { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }
}