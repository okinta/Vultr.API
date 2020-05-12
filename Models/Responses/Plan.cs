using System.Collections.Generic;
using System.Net;

namespace Vultr.API.Models.Responses
{
    public class Plan
    {
        public string VPSPLANID { get; set; }
        public string name { get; set; }
        public string vcpu_count { get; set; }
        public string ram { get; set; }
        public string disk { get; set; }
        public string bandwidth { get; set; }
        public string price_per_month { get; set; }
        public bool windows { get; set; }
        public string plan_type { get; set; }
        public int[] available_locations { get; set; }
        public bool deprecated { get; set; }
    }

    public struct PlanResult
    {
        public Dictionary<int, Plan> Plans { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }

    public class BareMetalPlan
    {
        public string METALPLANID { get; set; }
        public string name { get; set; }
        public int cpu_count { get; set; }
        public int ram { get; set; }
        public string disk { get; set; }
        public int bandwidth_tb { get; set; }
        public int price_per_month { get; set; }
        public string plan_type { get; set; }
        public bool deprecated { get; set; }
        public int[] available_locations { get; set; }
    }

    public struct BareMetalPlanResult
    {
        public Dictionary<int, BareMetalPlan> Plans { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }

    public class VC2Plan
    {
        public string VPSPLANID { get; set; }
        public string name { get; set; }
        public string vcpu_count { get; set; }
        public string ram { get; set; }
        public string disk { get; set; }
        public string bandwidth { get; set; }
        public string price_per_month { get; set; }
        public string plan_type { get; set; }
        public bool deprecated { get; set; }
        public int[] available_locations { get; set; }
    }

    public struct VC2PlanResult
    {
        public Dictionary<int, VC2Plan> Plans { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }

    public class VDC2Plan
    {
        public string VPSPLANID { get; set; }
        public string name { get; set; }
        public string vcpu_count { get; set; }
        public string ram { get; set; }
        public string disk { get; set; }
        public string bandwidth { get; set; }
        public string price_per_month { get; set; }
        public string plan_type { get; set; }
        public bool deprecated { get; set; }
        public int[] available_locations { get; set; }
    }

    public struct VDC2PlanResult
    {
        public Dictionary<int, VDC2Plan> Plans { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }
}