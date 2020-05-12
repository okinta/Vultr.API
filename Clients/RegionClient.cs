using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Vultr.API.Models.Responses;

namespace Vultr.API.Clients
{
    public class RegionClient
    {
        private readonly string _ApiKey;

        public RegionClient(string ApiKey)
        {
            _ApiKey = ApiKey;
        }

        public string Type { get; private set; }

        /// <summary>
        /// Retrieve a list of all active regions. Note that just because a region is listed here, does not mean that there is room for new servers.
        /// </summary>
        /// <returns>List of active regions.</returns>
        public RegionResult GetRegions()
        {
            var answer = new Dictionary<int, Region>();
            var httpResponse = Extensions.ApiClient.ApiExecute("regions/list?availability=yes", _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
                answer = JsonConvert.DeserializeObject<Dictionary<int, Region>>((st ?? "") == "[]" ? "{}" : st);
            }

            return new RegionResult() { ApiResponse = httpResponse, Regions = answer };
        }

        /// <summary>
        /// Retrieve a list of the VPSPLANIDs currently available in this location.
        /// </summary>
        /// <param name="DCID">Location to check availability.</param>
        /// <param name="type">The type of plans for which to include availability. Possible values: "all", "vc2", "ssd", "vdc2", "dedicated".</param>
        /// <returns>List of the VPSPLANIDs currently available in this location.</returns>
        public RegionAvailabilityResult GetAvailablePlans(int DCID, string type = "all")
        {
            if ((type ?? "") == "all" | (type ?? "") == "vc2" | (type ?? "") == "ssd" | (type ?? "") == "vdc2" | (type ?? "") == "dedicated")
            {
                Type = type;
            }
            else
            {
                Type = "all";
            }

            var answer = new PlanIdsClass();
            var httpResponse = Extensions.ApiClient.ApiExecute("regions/availability?DCID=" + DCID + "&type=" + Type, _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
                answer = JsonConvert.DeserializeObject<PlanIdsClass>((st ?? "") == "[]" ? "{}" : st);
            }

            return new RegionAvailabilityResult() { ApiResponse = httpResponse, PlanIds = answer };
        }

        /// <summary>
        /// Retrieve a list of the METALPLANIDs currently available in this location.
        /// </summary>
        /// <param name="DCID">Location to check availability.</param>
        /// <returns>List of the Bare Metal Plans currently available in this location.</returns>
        public RegionAvailabilityResult GetAvailableBareMetalPlans(int DCID)
        {
            var answer = new PlanIdsClass();
            var httpResponse = Extensions.ApiClient.ApiExecute("regions/availability_baremetal?DCID=" + DCID, _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
                answer = JsonConvert.DeserializeObject<PlanIdsClass>((st ?? "") == "[]" ? "{}" : st);
            }

            return new RegionAvailabilityResult() { ApiResponse = httpResponse, PlanIds = answer };
        }


        /// <summary>
        /// Retrieve a list of the vc2 VPSPLANIDs currently available in this location.
        /// </summary>
        /// <param name="DCID">Location to check availability.</param>
        /// <returns>List of the vc2 VPSPLANIDs currently available in this location.</returns>
        public RegionAvailabilityResult GetAvailableVC2Plans(int DCID)
        {
            var answer = new PlanIdsClass();
            var httpResponse = Extensions.ApiClient.ApiExecute("regions/availability_vc2?DCID=" + DCID, _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
                answer = JsonConvert.DeserializeObject<PlanIdsClass>((st ?? "") == "[]" ? "{}" : st);
            }

            return new RegionAvailabilityResult() { ApiResponse = httpResponse, PlanIds = answer };
        }

        /// <summary>
        /// Retrieve a list of the vdc2 VPSPLANIDs currently available in this location.
        /// </summary>
        /// <param name="DCID">Location to check availability.</param>
        /// <returns>List of the vdc2 VPSPLANIDs currently available in this location.</returns>
        public RegionAvailabilityResult GetAvailableVDC2Plans(int DCID)
        {
            var answer = new PlanIdsClass();
            var httpResponse = Extensions.ApiClient.ApiExecute("regions/availability_vdc2?DCID=" + DCID, _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
                answer = JsonConvert.DeserializeObject<PlanIdsClass>((st ?? "") == "[]" ? "{}" : st);
            }

            return new RegionAvailabilityResult() { ApiResponse = httpResponse, PlanIds = answer };
        }
    }
}