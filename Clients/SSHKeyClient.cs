using System.Collections.Generic;
using Vultr.API.Models.Responses;

namespace Vultr.API.Clients
{
    public class SSHKeyClient
    {
        private string ApiKey { get; }

        public SSHKeyClient(string apiKey)
        {
            ApiKey = apiKey;
        }

        /// <summary>
        /// List all the SSH keys on the current account.
        /// </summary>
        /// <returns>List of all the SSH keys on the current account.</returns>
        public SSHKeyResult GetSSHKeys()
        {
            var response = Extensions.ApiClient.ApiExecute<Dictionary<string, SSHKey>>(
                   "sshkey/list", ApiKey);
            return new SSHKeyResult()
            {
                ApiResponse = response.Item1,
                SSHKeys = response.Item2
            };
        }

        /// <summary>
        /// Create a new SSH Key.
        /// </summary>
        /// <param name="name">Name of the SSH key</param>
        /// <param name="ssh_key">SSH public key (in authorized_keys format)</param>
        /// <returns>SSHKey element with only SSHKEYID.</returns>
        public SSHKeyCreateResult CreateSSHKey(string name, string ssh_key)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("name", name),
                new KeyValuePair<string, object>("ssh_key", ssh_key)
            };

            var response = Extensions.ApiClient.ApiExecute<SSHKey>(
                "sshkey/create", ApiKey, args, "POST");
            return new SSHKeyCreateResult()
            {
                ApiResponse = response.Item1,
                SSHKey = response.Item2
            };
        }

        /// <summary>
        /// Remove a SSH key. Note that this will not remove the key from any machines that already have it.
        /// </summary>
        /// <param name="SSHKEYID">Unique identifier for this SSH key.  These can be found using the GetSSHKeys()</param>
        /// <returns>No response, check HTTP result code.</returns>
        public SSHKeyDeleteResult DeleteSSHKey(string SSHKEYID)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("SSHKEYID", SSHKEYID)
            };

            var response = Extensions.ApiClient.ApiExecute<SSHKey>(
                "sshkey/destroy", ApiKey, args, "POST");
            return new SSHKeyDeleteResult()
            {
                ApiResponse = response.Item1
            };
        }

        /// <summary>
        /// Update an existing SSH Key. Note that this will only update newly installed machines. The key will not be updated on any existing machines.
        /// </summary>
        /// <param name="SSHKey">Unique identifier for this snapshot. These can be found Using the GetSSHKeys() Call.</param>
        /// <returns>No response, check HTTP result code.</returns>
        public SSHKeyUpdateResult UpdateSSHKey(SSHKey SSHKey)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("name", SSHKey.name),
                new KeyValuePair<string, object>("SSHKEYID", SSHKey.SSHKEYID),
                new KeyValuePair<string, object>("ssh_key", SSHKey.ssh_key)
            };

            var response = Extensions.ApiClient.ApiExecute<SSHKey>(
                "sshkey/update", ApiKey, args, "POST");
            return new SSHKeyUpdateResult()
            {
                ApiResponse = response.Item1
            };
        }
    }
}
