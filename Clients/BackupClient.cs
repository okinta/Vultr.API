using System.Collections.Generic;
using Vultr.API.Extensions;
using Vultr.API.Models;

namespace Vultr.API.Clients
{
    public class BackupClient
    {
        private string ApiKey { get; }

        public BackupClient(string apiKey)
        {
            ApiKey = apiKey;
        }

        /// <summary>
        /// List all backups on the current account.
        /// </summary>
        /// <returns>Returns backup list and HTTP API Respopnse.</returns>
        public BackupResult GetBackups()
        {
            var response = ApiClient.ApiExecute<Dictionary<string, Backup>>(
                "backup/list", ApiKey);
            return new BackupResult()
            {
                ApiResponse = response.Item1,
                Backups = response.Item2
            };
        }

        /// <summary>
        /// Filter result set to only contain this backup.
        /// </summary>
        /// <param name="BackupId">BackupId for getting result for backup.</param>
        /// <returns>Returns backup and HTTP API Respopnse.</returns>
        public BackupResult GetBackupByBackupId(string BackupId)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("BACKUPID", BackupId)
            };

            var response = ApiClient.ApiExecute<Dictionary<string, Backup>>(
                "backup/list", ApiKey, args);
            return new BackupResult()
            {
                ApiResponse = response.Item1,
                Backups = response.Item2
            };
        }

        /// <summary>
        /// Filter result set to only contain backups of this subscription object.
        /// </summary>
        /// <param name="SubId">Filter result set to only contain backups of this subscription object</param>
        /// <returns>Returns backup and HTTP API Respopnse.</returns>
        public BackupResult GetBackupBySUBID(string SubId)
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("SUBID", SubId)
            };

            var response = ApiClient.ApiExecute<Dictionary<string, Backup>>(
                "backup/list", ApiKey, args, ApiMethod.POST);
            return new BackupResult()
            {
                ApiResponse = response.Item1,
                Backups = response.Item2
            };
        }
    }
}
