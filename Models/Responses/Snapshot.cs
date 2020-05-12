using System.Collections.Generic;
using System.Net;

namespace Vultr.API.Models.Responses
{
    public class Snapshot
    {
        public string ID { get; set; }

        public string DateCreated { get; set; }

        public string Description { get; set; }

        public string Size { get; set; }

        public string Status { get; set; }

        public string OSID { get; set; }

        public string APPID { get; set; }
    }

    public struct SnapshotCreateResult
    {
        public Snapshot Snapshot { get; set; }

        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct SnapshotDeleteResult
    {
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct SnapshotResult
    {
        public Dictionary<string, Snapshot> Snapshots { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }
}