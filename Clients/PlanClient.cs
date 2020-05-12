using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Vultr.API.Models.Responses;

namespace Vultr.API.Clients
{
    public class PlanClient
    {
        private readonly string _ApiKey;

        public PlanClient(string ApiKey)
        {
            _ApiKey = ApiKey;
        }

        public string Type { get; private set; }

        /// <summary>
        /// Retrieve a list of all active plans. Plans that are no longer available will not be shown. The "windows" field Is no longer in use, And will always be false. Windows licenses will be automatically added to any plan as necessary. The "deprecated" field indicates that the plan will be going away in the future. New deployments of it will still be accepted, but you should begin to transition away from its usage. Typically, deprecated plans are available for 30 days after they are deprecated. The sandbox plan Is Not available In the API.
        /// </summary>
        /// <param name="type">The type of plans to return. Possible values: "all", "vc2", "ssd", "vdc2", "dedicated".</param>
        /// <returns>List of active or deprecated plans.</returns>
        public PlanResult GetPlans(string type = "all")
        {
            if ((type ?? "") == "all" | (type ?? "") == "vc2" | (type ?? "") == "ssd" | (type ?? "") == "vdc2" | (type ?? "") == "dedicated")
            {
                Type = type;
            }
            else
            {
                Type = "all";
            }

            var answer = new Dictionary<int, Plan>();
            var httpResponse = Extensions.ApiClient.ApiExecute("plans/list?type=" + Type, _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
                answer = JsonConvert.DeserializeObject<Dictionary<int, Plan>>((st ?? "") == "[]" ? "{}" : st);
            }

            return new PlanResult() { ApiResponse = httpResponse, Plans = answer };
        }

        /// <summary>
        /// Retrieve a list of all active bare metal plans. Plans that are no longer available will not be shown. The 'deprecated' field indicates that the plan will be going away in the future. New deployments of it will still be accepted, but you should begin to transition away from its usage. Typically, deprecated plans are available for 30 days after they have been deprecated.
        /// </summary>
        /// <returns>List of active or deprecated bare metal plans.</returns>
        public BareMetalPlanResult GetBaremetalPlans()
        {
            var answer = new Dictionary<int, BareMetalPlan>();
            var httpResponse = Extensions.ApiClient.ApiExecute("plans/list_baremetal", _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                    answer = JsonConvert.DeserializeObject<Dictionary<int, BareMetalPlan>>((st ?? "") == "[]" ? "{}" : st);
                }
            }

            return new BareMetalPlanResult() { ApiResponse = httpResponse, Plans = answer };
        }

        /// <summary>
        /// Retrieve a list of all active vc2 plans. Plans that are no longer available will not be shown. The 'deprecated' field indicates that the plan will be going away in the future. New deployments of it will still be accepted, but you should begin to transition away from its usage. Typically, deprecated plans are available for 30 days after they are deprecated. Note: The sandbox plan Is Not available In the API.
        /// </summary>
        /// <returns>List of active or deprecated VC2 plans.</returns>
        public VC2PlanResult GetVC2Plans()
        {
            var answer = new Dictionary<int, VC2Plan>();
            var httpResponse = Extensions.ApiClient.ApiExecute("plans/list_vc2", _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                    answer = JsonConvert.DeserializeObject<Dictionary<int, VC2Plan>>((st ?? "") == "[]" ? "{}" : st);
                }
            }

            return new VC2PlanResult() { ApiResponse = httpResponse, Plans = answer };
        }

        /// <summary>
        /// Retrieve a list of all active vdc2 plans. Plans that are no longer available will not be shown. The 'deprecated' field indicates that the plan will be going away in the future. New deployments of it will still be accepted, but you should begin to transition away from its usage. Typically, deprecated plans are available for 30 days after they are deprecated.
        /// </summary>
        /// <returns>List of active or deprecated VDC2 plans.</returns>
        public VDC2PlanResult GetVDC2Plans()
        {
            var answer = new Dictionary<int, VDC2Plan>();
            var httpResponse = Extensions.ApiClient.ApiExecute("plans/list_vdc2", _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                    answer = JsonConvert.DeserializeObject<Dictionary<int, VDC2Plan>>((st ?? "") == "[]" ? "{}" : st);
                }
            }

            return new VDC2PlanResult() { ApiResponse = httpResponse, Plans = answer };
        }
    }
}