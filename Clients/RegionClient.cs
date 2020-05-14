using System.Collections.Generic;
using Vultr.API.Models;
using Vultr.Clients;

namespace Vultr.API.Clients
{
    public class RegionClient : BaseClient
    {
        public RegionClient(string apiKey, string apiURL) : base(apiKey, apiURL) { }

        /// <summary>
        /// Retrieve a list of all active regions. Note that just because a region is listed here, does not mean that there is room for new servers.
        /// </summary>
        /// <returns>List of active regions.</returns>
        public RegionResult GetRegions()
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("availability", true),
            };

            var response = ApiExecute<Dictionary<int, Region>>(
                "regions/list", ApiKey, args);
            return new RegionResult()
            {
                ApiResponse = response.Item1,
                Regions = response.Item2
            };
        }

        /// <summary>
        /// Retrieve a list of the VPSPLANIDs currently available in this location.
        /// </summary>
        /// <param name="DCID">Location to check availability.</param>
        /// <param name="type">The type of plans for which to include availability. Possible values: "all", "vc2", "ssd", "vdc2", "dedicated".</param>
        /// <returns>List of the VPSPLANIDs currently available in this location.</returns>
        public RegionAvailabilityResult GetAvailablePlans(int DCID, string type = "all")
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("DCID", DCID),
            };

            if ((type ?? "") == "all" | (type ?? "") == "vc2" | (type ?? "") == "ssd" | (type ?? "") == "vdc2" | (type ?? "") == "dedicated")
            {
                args.Add(new KeyValuePair<string, object>("type", type));
            }
            else
            {
                args.Add(new KeyValuePair<string, object>("type", "all"));
            }

            var response = ApiExecute<PlanIdsClass>(
                "regions/availability", ApiKey, args);
            return new RegionAvailabilityResult()
            {
                ApiResponse = response.Item1,
                PlanIds = response.Item2
            };
        }

        /// <summary>
        /// Retrieve a list of the METALPLANIDs currently available in this location.
        /// </summary>
        /// <param name="DCID">Location to check availability.</param>
        /// <returns>List of the Bare Metal Plans currently available in this location.</returns>
        public RegionAvailabilityResult GetAvailableBareMetalPlans(int DCID)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("DCID", DCID),
            };

            var response = ApiExecute<PlanIdsClass>(
                "regions/availability_baremetal", ApiKey, args);
            return new RegionAvailabilityResult()
            {
                ApiResponse = response.Item1,
                PlanIds = response.Item2
            };
        }

        /// <summary>
        /// Retrieve a list of the vc2 VPSPLANIDs currently available in this location.
        /// </summary>
        /// <param name="DCID">Location to check availability.</param>
        /// <returns>List of the vc2 VPSPLANIDs currently available in this location.</returns>
        public RegionAvailabilityResult GetAvailableVC2Plans(int DCID)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("DCID", DCID),
            };

            var response = ApiExecute<PlanIdsClass>(
                "regions/availability_vc2", ApiKey, args);
            return new RegionAvailabilityResult()
            {
                ApiResponse = response.Item1,
                PlanIds = response.Item2
            };
        }

        /// <summary>
        /// Retrieve a list of the vdc2 VPSPLANIDs currently available in this location.
        /// </summary>
        /// <param name="DCID">Location to check availability.</param>
        /// <returns>List of the vdc2 VPSPLANIDs currently available in this location.</returns>
        public RegionAvailabilityResult GetAvailableVDC2Plans(int DCID)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("DCID", DCID),
            };

            var response = ApiExecute<PlanIdsClass>(
                "regions/availability_vdc2", ApiKey, args);
            return new RegionAvailabilityResult()
            {
                ApiResponse = response.Item1,
                PlanIds = response.Item2
            };
        }
    }
}
