using System.Collections.Generic;
using System.Net.Http;

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
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public struct SSHKeyDeleteResult
    {
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public struct SSHKeyUpdateResult
    {
        public HttpResponseMessage ApiResponse { get; set; }
    }

    public struct SSHKeyResult
    {
        public Dictionary<string, SSHKey> SSHKeys { get; set; }
        public HttpResponseMessage ApiResponse { get; set; }
    }
}
