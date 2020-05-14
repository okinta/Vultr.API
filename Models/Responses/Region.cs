using System.Collections.Generic;
using System.Net.Http;

namespace Vultr.API.Models.Responses
{
    public class Region
    {
        public string DCID { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string continent { get; set; }
        public string state { get; set; }
        public bool ddos_protection { get; set; }
        public bool block_storage { get; set; }
        public string regioncode { get; set; }
        public int[] availability { get; set; }
    }

    public struct RegionResult
    {
        public Dictionary<int, Region> Regions { get; set; }
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public class PlanIdsClass
    {
        public static int[] PlanIds { get; set; }
    }

    public struct RegionAvailabilityResult
    {
        public PlanIdsClass PlanIds { get; set; }
        public HttpResponseMessage ApiResponse { get; set; }
    }
}
