﻿using System.Collections.Generic;
using Vultr.API.Models;
using Vultr.Clients;

namespace Vultr.API.Clients
{
    public class BlockClient : BaseClient
    {
        public BlockClient(string apiKey, string apiURL) : base(apiKey, apiURL) { }

        /// <summary>
        /// Retrieve a list of any active block storage subscriptions on this account.
        /// </summary>
        /// <param name="SUBID">Unique identifier of a subscription. Only the subscription object will be returned.</param>
        /// <returns>List of all any active block storage subscriptions on this account.</returns>
        public BlockResult GetBlocks(int? SUBID = null)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("SUBID", SUBID)
            };

            var response = ApiExecute<List<Block>>(
                "block/list", ApiKey, args);
            return new BlockResult()
            {
                ApiResponse = response.Item1,
                Blocks = response.Item2
            };
        }

        /// <summary>
        /// Resize the block storage volume to a new size. WARNING: When shrinking the volume, you must manually shrink the filesystem And partitions beforehand, Or you will lose data.
        /// </summary>
        /// <param name="SUBID">ID of the block storage subscription to resize</param>
        /// <param name="size_gb">New size (in GB) of the block storage subscription</param>
        /// <returns>No response, check HTTP result code.</returns>
        public BlockUpdateResult ResizeBlock(int SUBID, int size_gb)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("SUBID", SUBID),
                new KeyValuePair<string, object>("size_gb", size_gb)
            };

            var response = ApiExecute<Block>(
                "block/resize", ApiKey, args, ApiMethod.POST);
            return new BlockUpdateResult()
            {
                ApiResponse = response.Item1
            };
        }

        /// <summary>
        /// Set the label of a block storage subscription.
        /// </summary>
        /// <param name="SUBID">ID of the block storage subscription to rename</param>
        /// <param name="label">Text label that will be shown in the control panel.</param>
        /// <returns>No response, check HTTP result code.</returns>
        public BlockUpdateResult RenameBlock(int SUBID, string label)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("SUBID", SUBID),
                new KeyValuePair<string, object>("label", label)
            };

            var response = ApiExecute<Block>(
                "block/label_set", ApiKey, args, ApiMethod.POST);
            return new BlockUpdateResult()
            {
                ApiResponse = response.Item1
            };
        }

        /// <summary>
        /// Create a block storage subscription.
        /// </summary>
        /// <param name="DCID">DCID of the location to create this subscription in. See GetRegions()</param>
        /// <param name="Block">Block object of this subscription. (Size_gb and label will be used only)</param>
        /// <returns>Return block object with only SUBID.</returns>
        public BlockCreateResult CreateBlock(int DCID, Block Block)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("DCID", DCID),
                new KeyValuePair<string, object>("size_gb", Block.size_gb),
                new KeyValuePair<string, object>("label", Block.label)
            };

            var response = ApiExecute<Block>(
                "block/create", ApiKey, args, ApiMethod.POST);
            return new BlockCreateResult()
            {
                ApiResponse = response.Item1,
                Block = response.Item2
            };
        }

        /// <summary>
        /// Attach a block storage subscription to a VPS subscription. The block storage volume must not be attached to any other VPS subscriptions for this to work.
        /// </summary>
        /// <param name="SUBID">ID of the block storage subscription to attach</param>
        /// <param name="attach_to_SUBID">ID of the VPS subscription to mount the block storage subscription to</param>
        /// <returns>No response, check HTTP result code.</returns>
        public BlockUpdateResult AttachBlock(int SUBID, int attach_to_SUBID)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("SUBID", SUBID),
                new KeyValuePair<string, object>("attach_to_SUBID", attach_to_SUBID)
            };

            var response = ApiExecute<Block>(
                "block/update", ApiKey, args, ApiMethod.POST);
            return new BlockUpdateResult()
            {
                ApiResponse = response.Item1
            };
        }

        /// <summary>
        /// Detach a block storage subscription from the currently attached instance.
        /// </summary>
        /// <param name="SUBID">ID of the block storage subscription to detach</param>
        /// <returns>No response, check HTTP result code.</returns>
        public BlockUpdateResult DetachBlock(int SUBID)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("SUBID", SUBID)
            };

            var response = ApiExecute<Block>(
                "block/detach", ApiKey, args, ApiMethod.POST);
            return new BlockUpdateResult()
            {
                ApiResponse = response.Item1
            };
        }

        /// <summary>
        /// Delete a block storage subscription. All data will be permanently lost. There is no going back from this call.
        /// </summary>
        /// <param name="SUBID">ID of the block storage subscription to delete</param>
        /// <returns>No response, check HTTP result code.</returns>
        public BlockUpdateResult DeleteBlock(int SUBID)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("SUBID", SUBID)
            };

            var response = ApiExecute<Block>(
                "server/create", ApiKey, args, ApiMethod.POST);
            return new BlockUpdateResult()
            {
                ApiResponse = response.Item1
            };
        }
    }
}
