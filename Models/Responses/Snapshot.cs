using System.Collections.Generic;
using System.Net;

namespace Vultr.API.Models.Responses
{
    public class Snapshot
    {
        public string SNAPSHOTID { get; set; }
        public string date_created { get; set; }
        public string description { get; set; }
        public string size { get; set; }
        public string status { get; set; }
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