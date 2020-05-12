using System.Collections.Generic;
using System.Net;

namespace Vultr.API.Models.Responses
{
    public class Block
    {
        public int SUBID { get; set; }
        public string DateCreated { get; set; }
        public int CostPerMonth { get; set; }
        public string Status { get; set; }
        public int SizeGB { get; set; }
        public int DCID { get; set; }
        public int? AttachedToSUBID { get; set; }
        public string Label { get; set; }
    }

    public struct BlockCreateResult
    {
        public Block Block { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct BlockResult
    {
        public List<Block> Blocks { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct BlockUpdateResult
    {
        public HttpWebResponse ApiResponse { get; set; }
    }
}