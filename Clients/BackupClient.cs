using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Vultr.API.Models.Responses;

namespace Vultr.API.Clients
{
    public class BackupClient
    {
        private readonly string _ApiKey;

        public BackupClient(string ApiKey)
        {
            _ApiKey = ApiKey;
        }

        /// <summary>
        /// List all backups on the current account.
        /// </summary>
        /// <returns>Returns backup list and HTTP API Respopnse.</returns>
        public BackupResult GetBackups()
        {
            var answer = new BackupResult();
            var httpResponse = Extensions.ApiClient.ApiExecute("backup/list", _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                    answer.Backups = JsonConvert.DeserializeObject<Dictionary<string, Backup>>((st ?? "") == "[]" ? "{}" : st);
                }
            }

            return new BackupResult() { ApiResponse = httpResponse, Backups = answer.Backups };
        }

        /// <summary>
        /// Filter result set to only contain this backup.
        /// </summary>
        /// <param name="BackupId">BackupId for getting result for backup.</param>
        /// <returns>Returns backup and HTTP API Respopnse.</returns>
        public BackupResult GetBackupByBackupId(string BackupId)
        {
            var dict = new List<KeyValuePair<string, object>>();
            dict.Add(new KeyValuePair<string, object>("BACKUPID", BackupId));
            var answer = new BackupResult();
            var httpResponse = Extensions.ApiClient.ApiExecute("backup/list", _ApiKey, dict);
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                    answer.Backups = JsonConvert.DeserializeObject<Dictionary<string, Backup>>((st ?? "") == "[]" ? "{}" : st);
                }
            }

            return new BackupResult() { ApiResponse = httpResponse, Backups = answer.Backups };
        }

        /// <summary>
        /// Filter result set to only contain backups of this subscription object.
        /// </summary>
        /// <param name="SubId">Filter result set to only contain backups of this subscription object</param>
        /// <returns>Returns backup and HTTP API Respopnse.</returns>
        public BackupResult GetBackupBySUBID(string SubId)
        {
            var dict = new List<KeyValuePair<string, object>>();
            dict.Add(new KeyValuePair<string, object>("SUBID", SubId));
            var answer = new BackupResult();
            var httpResponse = Extensions.ApiClient.ApiExecute("backup/list", _ApiKey, dict);
            if ((int)httpResponse.StatusCode == 200)
            {
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string st = streamReader.ReadToEnd();
                    answer.Backups = JsonConvert.DeserializeObject<Dictionary<string, Backup>>((st ?? "") == "[]" ? "{}" : st);
                }
            }

            return new BackupResult() { ApiResponse = httpResponse, Backups = answer.Backups };
        }
    }
}