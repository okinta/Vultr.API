using System.Collections.Generic;
using System.Net.Http;

namespace Vultr.API.Models.Responses
{
    public class Block
    {
        public int SUBID { get; set; }
        public string date_created { get; set; }
        public int cost_per_month { get; set; }
        public string status { get; set; }
        public int size_gb { get; set; }
        public int DCID { get; set; }
        public int? attached_to_SUBID { get; set; }
        public string label { get; set; }
    }

    public struct BlockCreateResult
    {
        public Block Block { get; set; }
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public struct BlockResult
    {
        public List<Block> Blocks { get; set; }
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public struct BlockUpdateResult
    {
        public HttpResponseMessage ApiResponse { get; set; }
    }
}
