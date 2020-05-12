using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Vultr.API.Models.Responses;

namespace Vultr.API.Clients
{
    public class SnapshotClient
    {
        private readonly string _ApiKey;

        public SnapshotClient(string ApiKey)
        {
            _ApiKey = ApiKey;
        }

        /// <summary>
        /// List all snapshots on the current account.
        /// </summary>
        /// <returns>List of all snapshots on the current account.</returns>
        public SnapshotResult GetSnapshots()
        {
            var answer = new Dictionary<string, Snapshot>();
            var httpResponse = Extensions.ApiClient.ApiExecute("snapshot/list", _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                    answer = JsonConvert.DeserializeObject<Dictionary<string, Snapshot>>((st ?? "") == "[]" ? "{}" : st);
                }
            }

            return new SnapshotResult() { ApiResponse = httpResponse, Snapshots = answer };
        }

        /// <summary>
        /// Create a snapshot from an existing virtual machine. The virtual machine does not need to be stopped.
        /// </summary>
        /// <param name="SUBID">Identifier of the virtual machine to create a snapshot from.</param>
        /// <param name="Description">Description of snapshot contents</param>
        /// <returns>Network element with only NETWORKID.</returns>
        public SnapshotCreateResult CreateSnapshot(int SUBID, string Description)
        {
            var dict = new List<KeyValuePair<string, object>>();
            dict.Add(new KeyValuePair<string, object>("SUBID", SUBID));
            dict.Add(new KeyValuePair<string, object>("description", Description));
            var answer = new Snapshot();
            var httpResponse = Extensions.ApiClient.ApiExecute("snapshot/create", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                    answer = JsonConvert.DeserializeObject<Snapshot>((st ?? "") == "[]" ? "{}" : st);
                }
            }

            return new SnapshotCreateResult() { ApiResponse = httpResponse, Snapshot = answer };
        }

        /// <summary>
        /// Destroy (delete) a snapshot. There is no going back from this call.
        /// </summary>
        /// <param name="SNAPSHOTID">Unique identifier for this snapshot. These can be found Using the GetSnapshots() Call.</param>
        /// <returns>No response, check HTTP result code.</returns>
        public SnapshotDeleteResult DeleteSnapshot(string SNAPSHOTID)
        {
            var dict = new List<KeyValuePair<string, object>>();
            dict.Add(new KeyValuePair<string, object>("SNAPSHOTID", SNAPSHOTID));
            var httpResponse = Extensions.ApiClient.ApiExecute("snapshot/destroy", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                }
            }

            return new SnapshotDeleteResult() { ApiResponse = httpResponse };
        }
    }
}