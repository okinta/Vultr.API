using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Vultr.API.Models.Responses;

namespace Vultr.API.Clients
{
    public class SSHKeyClient
    {
        private readonly string _ApiKey;

        public SSHKeyClient(string ApiKey)
        {
            _ApiKey = ApiKey;
        }

        /// <summary>
        /// List all the SSH keys on the current account.
        /// </summary>
        /// <returns>List of all the SSH keys on the current account.</returns>
        public SSHKeyResult GetSSHKeys()
        {
            var answer = new Dictionary<string, SSHKey>();
            var httpResponse = Extensions.ApiClient.ApiExecute("sshkey/list", _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                    answer = JsonConvert.DeserializeObject<Dictionary<string, SSHKey>>((st ?? "") == "[]" ? "{}" : st);
                }
            }

            return new SSHKeyResult() { ApiResponse = httpResponse, SSHKeys = answer };
        }

        /// <summary>
        /// Create a new SSH Key.
        /// </summary>
        /// <param name="name">Name of the SSH key</param>
        /// <param name="ssh_key">SSH public key (in authorized_keys format)</param>
        /// <returns>SSHKey element with only SSHKEYID.</returns>
        public SSHKeyCreateResult CreateSSHKey(string name, string ssh_key)
        {
            var dict = new List<KeyValuePair<string, object>>();
            dict.Add(new KeyValuePair<string, object>("name", name));
            dict.Add(new KeyValuePair<string, object>("ssh_key", ssh_key));
            var answer = new SSHKey();
            var httpResponse = Extensions.ApiClient.ApiExecute("sshkey/create", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                    answer = JsonConvert.DeserializeObject<SSHKey>((st ?? "") == "[]" ? "{}" : st);
                }
            }

            return new SSHKeyCreateResult() { ApiResponse = httpResponse, SSHKey = answer };
        }

        /// <summary>
        /// Remove a SSH key. Note that this will not remove the key from any machines that already have it.
        /// </summary>
        /// <param name="SSHKEYID">Unique identifier for this SSH key.  These can be found using the GetSSHKeys()</param>
        /// <returns>No response, check HTTP result code.</returns>
        public SSHKeyDeleteResult DeleteSSHKey(string SSHKEYID)
        {
            var dict = new List<KeyValuePair<string, object>>();
            dict.Add(new KeyValuePair<string, object>("SSHKEYID", SSHKEYID));
            var httpResponse = Extensions.ApiClient.ApiExecute("sshkey/destroy", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                }
            }

            return new SSHKeyDeleteResult() { ApiResponse = httpResponse };
        }

        /// <summary>
        /// Update an existing SSH Key. Note that this will only update newly installed machines. The key will not be updated on any existing machines.
        /// </summary>
        /// <param name="SSHKey">Unique identifier for this snapshot. These can be found Using the GetSSHKeys() Call.</param>
        /// <returns>No response, check HTTP result code.</returns>
        public SSHKeyUpdateResult UpdateSSHKey(SSHKey SSHKey)
        {
            var dict = new List<KeyValuePair<string, object>>();
            dict.Add(new KeyValuePair<string, object>("name", SSHKey.name));
            dict.Add(new KeyValuePair<string, object>("SSHKEYID", SSHKey.SSHKEYID));
            dict.Add(new KeyValuePair<string, object>("ssh_key", SSHKey.ssh_key));
            var httpResponse = Extensions.ApiClient.ApiExecute("sshkey/update", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                }
            }

            return new SSHKeyUpdateResult() { ApiResponse = httpResponse };
        }
    }
}