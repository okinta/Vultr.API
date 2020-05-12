using System.Collections.Generic;
using System.Net;

namespace Vultr.API.Models.Responses
{
    public class SSHKey
    {
        public string SSHKEYID { get; set; }
        public object date_created { get; set; }
        public string name { get; set; }
        public string ssh_key { get; set; }
    }

    public struct SSHKeyCreateResult
    {
        public SSHKey SSHKey { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct SSHKeyDeleteResult
    {
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct SSHKeyUpdateResult
    {
        public HttpWebResponse ApiResponse { get; set; }
    }

    public struct SSHKeyResult
    {
        public Dictionary<string, SSHKey> SSHKeys { get; set; }
        public HttpWebResponse ApiResponse { get; set; }
    }
}