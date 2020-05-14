using System.Collections.Generic;
using Vultr.API.Extensions;
using Vultr.API.Models.Responses;

namespace Vultr.API.Clients
{
    public class SnapshotClient
    {
        private string ApiKey { get; }

        public SnapshotClient(string apiKey)
        {
            ApiKey = apiKey;
        }

        /// <summary>
        /// List all snapshots on the current account.
        /// </summary>
        /// <returns>List of all snapshots on the current account.</returns>
        public SnapshotResult GetSnapshots()
        {
            var response = ApiClient.ApiExecute<Dictionary<string, Snapshot>>(
                "snapshot/list", ApiKey);
            return new SnapshotResult()
            {
                ApiResponse = response.Item1,
                Snapshots = response.Item2
            };
        }

        /// <summary>
        /// Create a snapshot from an existing virtual machine. The virtual machine does not need to be stopped.
        /// </summary>
        /// <param name="SUBID">Identifier of the virtual machine to create a snapshot from.</param>
        /// <param name="Description">Description of snapshot contents</param>
        /// <returns>Network element with only NETWORKID.</returns>
        public SnapshotCreateResult CreateSnapshot(int SUBID, string Description)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("SUBID", SUBID),
                new KeyValuePair<string, object>("description", Description)
            };

            var response = ApiClient.ApiExecute<Snapshot>(
                "snapshot/create", ApiKey, args, ApiMethod.POST);
            return new SnapshotCreateResult()
            {
                ApiResponse = response.Item1,
                Snapshot = response.Item2
            };
        }

        /// <summary>
        /// Destroy (delete) a snapshot. There is no going back from this call.
        /// </summary>
        /// <param name="SNAPSHOTID">Unique identifier for this snapshot. These can be found Using the GetSnapshots() Call.</param>
        /// <returns>No response, check HTTP result code.</returns>
        public SnapshotDeleteResult DeleteSnapshot(string SNAPSHOTID)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("SNAPSHOTID", SNAPSHOTID)
            };

            var response = ApiClient.ApiExecute<Snapshot>(
                "snapshot/destroy", ApiKey, args, ApiMethod.POST);
            return new SnapshotDeleteResult()
            {
                ApiResponse = response.Item1
            };
        }
    }
}
