using System.Collections.Generic;
using Vultr.API.Extensions;
using Vultr.API.Models;
using Vultr.Clients;

namespace Vultr.API.Clients
{
    public class PlanClient : BaseClient
    {
        public PlanClient(string apiKey, string apiURL) : base(apiKey, apiURL) { }

        /// <summary>
        /// Retrieve a list of all active plans. Plans that are no longer available will not be shown. The "windows" field Is no longer in use, And will always be false. Windows licenses will be automatically added to any plan as necessary. The "deprecated" field indicates that the plan will be going away in the future. New deployments of it will still be accepted, but you should begin to transition away from its usage. Typically, deprecated plans are available for 30 days after they are deprecated. The sandbox plan Is Not available In the API.
        /// </summary>
        /// <param name="type">The type of plans to return. Possible values: "all", "vc2", "ssd", "vdc2", "dedicated".</param>
        /// <returns>List of active or deprecated plans.</returns>
        public PlanResult GetPlans(string type = "all")
        {
            var args = new List<KeyValuePair<string, object>>();

            if ((type ?? "") == "all" | (type ?? "") == "vc2" | (type ?? "") == "ssd" | (type ?? "") == "vdc2" | (type ?? "") == "dedicated")
            {
                args.Add(new KeyValuePair<string, object>("type", type));
            }
            else
            {
                args.Add(new KeyValuePair<string, object>("type", "all"));
            }

            var response = ApiClient.ApiExecute<Dictionary<int, Plan>>(
                "plans/list", ApiKey, args);
            return new PlanResult()
            {
                ApiResponse = response.Item1,
                Plans = response.Item2
            };
        }

        /// <summary>
        /// Retrieve a list of all active bare metal plans. Plans that are no longer available will not be shown. The 'deprecated' field indicates that the plan will be going away in the future. New deployments of it will still be accepted, but you should begin to transition away from its usage. Typically, deprecated plans are available for 30 days after they have been deprecated.
        /// </summary>
        /// <returns>List of active or deprecated bare metal plans.</returns>
        public BareMetalPlanResult GetBaremetalPlans()
        {
            var response = ApiClient.ApiExecute<Dictionary<int, BareMetalPlan>>(
                "plans/list_baremetal", ApiKey);
            return new BareMetalPlanResult()
            {
                ApiResponse = response.Item1,
                Plans = response.Item2
            };
        }

        /// <summary>
        /// Retrieve a list of all active vc2 plans. Plans that are no longer available will not be shown. The 'deprecated' field indicates that the plan will be going away in the future. New deployments of it will still be accepted, but you should begin to transition away from its usage. Typically, deprecated plans are available for 30 days after they are deprecated. Note: The sandbox plan Is Not available In the API.
        /// </summary>
        /// <returns>List of active or deprecated VC2 plans.</returns>
        public VC2PlanResult GetVC2Plans()
        {
            var response = ApiClient.ApiExecute<Dictionary<int, VC2Plan>>(
                "plans/list_vc2", ApiKey);
            return new VC2PlanResult()
            {
                ApiResponse = response.Item1,
                Plans = response.Item2
            };
        }

        /// <summary>
        /// Retrieve a list of all active vdc2 plans. Plans that are no longer available will not be shown. The 'deprecated' field indicates that the plan will be going away in the future. New deployments of it will still be accepted, but you should begin to transition away from its usage. Typically, deprecated plans are available for 30 days after they are deprecated.
        /// </summary>
        /// <returns>List of active or deprecated VDC2 plans.</returns>
        public VDC2PlanResult GetVDC2Plans()
        {
            var response = ApiClient.ApiExecute<Dictionary<int, VDC2Plan>>(
                "plans/list_vdc2", ApiKey);
            return new VDC2PlanResult()
            {
                ApiResponse = response.Item1,
                Plans = response.Item2
            };
        }
    }
}
