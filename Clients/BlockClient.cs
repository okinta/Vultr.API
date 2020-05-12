using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Vultr.API.Models.Responses;

namespace Vultr.API.Clients
{
    public class BlockClient
    {
        private readonly string _ApiKey;

        public BlockClient(string ApiKey)
        {
            _ApiKey = ApiKey;
        }

        /// <summary>
        /// Retrieve a list of any active block storage subscriptions on this account.
        /// </summary>
        /// <param name="SUBID">Unique identifier of a subscription. Only the subscription object will be returned.</param>
        /// <returns>List of all any active block storage subscriptions on this account.</returns>
        public BlockResult GetBlocks(int SUBID = default)
        {
            var answer = new List<Block>();
            var httpResponse = Extensions.ApiClient.ApiExecute("block/list" + (Information.IsNothing(SUBID) ? "" : "?SUBID=" + SUBID), _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                    answer = JsonConvert.DeserializeObject<List<Block>>((st ?? "") == "[]" ? "{}" : st);
                }
            }

            return new BlockResult() { ApiResponse = httpResponse, Blocks = answer };
        }

        /// <summary>
        /// Resize the block storage volume to a new size. WARNING: When shrinking the volume, you must manually shrink the filesystem And partitions beforehand, Or you will lose data.
        /// </summary>
        /// <param name="SUBID">ID of the block storage subscription to resize</param>
        /// <param name="size_gb">New size (in GB) of the block storage subscription</param>
        /// <returns>No response, check HTTP result code.</returns>
        public BlockUpdateResult ResizeBlock(int SUBID, int size_gb)
        {
            var dict = new List<KeyValuePair<string, object>>();
            dict.Add(new KeyValuePair<string, object>("SUBID", SUBID));
            dict.Add(new KeyValuePair<string, object>("size_gb", size_gb));
            var httpResponse = Extensions.ApiClient.ApiExecute("block/resize", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                }
            }

            return new BlockUpdateResult() { ApiResponse = httpResponse };
        }

        /// <summary>
        /// Set the label of a block storage subscription.
        /// </summary>
        /// <param name="SUBID">ID of the block storage subscription to rename</param>
        /// <param name="label">Text label that will be shown in the control panel.</param>
        /// <returns>No response, check HTTP result code.</returns>
        public BlockUpdateResult RenameBlock(int SUBID, string label)
        {
            var dict = new List<KeyValuePair<string, object>>();
            dict.Add(new KeyValuePair<string, object>("SUBID", SUBID));
            dict.Add(new KeyValuePair<string, object>("label", label));
            var httpResponse = Extensions.ApiClient.ApiExecute("block/label_set", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                }
            }

            return new BlockUpdateResult() { ApiResponse = httpResponse };
        }

        /// <summary>
        /// Create a block storage subscription.
        /// </summary>
        /// <param name="DCID">DCID of the location to create this subscription in. See GetRegions()</param>
        /// <param name="Block">Block object of this subscription. (Size_gb and label will be used only)</param>
        /// <returns>Return block object with only SUBID.</returns>
        public BlockCreateResult CreateBlock(int DCID, Block Block)
        {
            var answer = new Block();
            var dict = new List<KeyValuePair<string, object>>();
            dict.Add(new KeyValuePair<string, object>("DCID", DCID));
            dict.Add(new KeyValuePair<string, object>("size_gb", Block.size_gb));
            dict.Add(new KeyValuePair<string, object>("label", Block.label));
            var httpResponse = Extensions.ApiClient.ApiExecute("block/create", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                    answer = JsonConvert.DeserializeObject<Block>((st ?? "") == "[]" ? "{}" : st);
                }
            }

            return new BlockCreateResult() { ApiResponse = httpResponse, Block = answer };
        }

        /// <summary>
        /// Attach a block storage subscription to a VPS subscription. The block storage volume must not be attached to any other VPS subscriptions for this to work.
        /// </summary>
        /// <param name="SUBID">ID of the block storage subscription to attach</param>
        /// <param name="attach_to_SUBID">ID of the VPS subscription to mount the block storage subscription to</param>
        /// <returns>No response, check HTTP result code.</returns>
        public BlockUpdateResult AttachBlock(int SUBID, int attach_to_SUBID)
        {
            var answer = new Block();
            var dict = new List<KeyValuePair<string, object>>();
            dict.Add(new KeyValuePair<string, object>("SUBID", SUBID));
            dict.Add(new KeyValuePair<string, object>("attach_to_SUBID", attach_to_SUBID));
            var httpResponse = Extensions.ApiClient.ApiExecute("block/attach", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                }
            }

            return new BlockUpdateResult() { ApiResponse = httpResponse };
        }

        /// <summary>
        /// Detach a block storage subscription from the currently attached instance.
        /// </summary>
        /// <param name="SUBID">ID of the block storage subscription to detach</param>
        /// <returns>No response, check HTTP result code.</returns>
        public BlockUpdateResult DetachBlock(int SUBID)
        {
            var answer = new Block();
            var dict = new List<KeyValuePair<string, object>>();
            dict.Add(new KeyValuePair<string, object>("SUBID", SUBID));
            var httpResponse = Extensions.ApiClient.ApiExecute("block/detach", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                }
            }

            return new BlockUpdateResult() { ApiResponse = httpResponse };
        }

        /// <summary>
        /// Delete a block storage subscription. All data will be permanently lost. There is no going back from this call.
        /// </summary>
        /// <param name="SUBID">ID of the block storage subscription to delete</param>
        /// <returns>No response, check HTTP result code.</returns>
        public BlockUpdateResult DeleteBlock(int SUBID)
        {
            var answer = new Block();
            var dict = new List<KeyValuePair<string, object>>();
            dict.Add(new KeyValuePair<string, object>("SUBID", SUBID));
            var httpResponse = Extensions.ApiClient.ApiExecute("block/delete", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                }
            }

            return new BlockUpdateResult() { ApiResponse = httpResponse };
        }
    }
}