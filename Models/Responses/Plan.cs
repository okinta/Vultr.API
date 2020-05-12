using System.Collections.Generic;
using System.Net;

namespace Vultr.API.Models.Responses
{
    public class Plan
    {
        public string VPSPLANID { get; set; }
        public string Name { get; set; }
        public string VPUCcount { get; set; }
        public string Ram { get; set; }
        public string Disk { get; set; }
        public string Bandwidth { get; set; }
        public string PricePerMonth { get; set; }
        public bool Windows { get; set; }
        public string PlanType { get; set; }
        public int[] AvailableLocations { get; set; }
        public bool Deprecated { get; set; }
    }

    public struct PlanResult
    {
        public Dictionary<int, Plan> Plans { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }

    public class BareMetalPlan
    {
        public string METALPLANID { get; set; }
        public string Name { get; set; }
        public int CPUCount { get; set; }
        public int Ram { get; set; }
        public string Disk { get; set; }
        public int BandwidthTB { get; set; }
        public int PricepPerMonth { get; set; }
        public string PlanType { get; set; }
        public bool Deprecated { get; set; }
        public int[] AvailableLocations { get; set; }
    }

    public struct BareMetalPlanResult
    {
        public Dictionary<int, BareMetalPlan> Plans { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }

    public class VC2Plan
    {
        public string VPSPLANID { get; set; }
        public string Name { get; set; }
        public string VCPUCount { get; set; }
        public string Ram { get; set; }
        public string Disk { get; set; }
        public string Bandwidth { get; set; }
        public string PricePerMonth { get; set; }
        public string PlanType { get; set; }
        public bool Deprecated { get; set; }
        public int[] AvailableLocations { get; set; }
    }

    public struct VC2PlanResult
    {
        public Dictionary<int, VC2Plan> Plans { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }

    public class VDC2Plan
    {
        public string VPSPLANID { get; set; }
        public string Name { get; set; }
        public string VCPUCount { get; set; }
        public string Ram { get; set; }
        public string Disk { get; set; }
        public string Bandwidth { get; set; }
        public string PricePerMonth { get; set; }
        public string PlanType { get; set; }
        public bool Deprecated { get; set; }
        public int[] AvailableLocations { get; set; }
    }

    public struct VDC2PlanResult
    {
        public Dictionary<int, VDC2Plan> Plans { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }
}