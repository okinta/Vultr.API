using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Vultr.API.Models.Responses;

namespace Vultr.API.Clients
{
    public class ServerClient
    {
        private readonly string _ApiKey;

        public ServerClient(string ApiKey)
        {
            _ApiKey = ApiKey;
        }

        /// <summary>
        /// List all active or pending virtual machines on the current account. The "status" field represents the status of the subscription And will be one of pending | active | suspended | closed. If the status Is "active", you can check "power_status" to determine if the VPS Is powered on Or Not. When status Is "active", you may also use "server_state" for a more detailed status of: none | locked | installingbooting | isomounting | ok. The API does Not provide any way To determine If the initial installation has completed Or Not. The "v6_network", "v6_main_ip", And "v6_network_size" fields are deprecated In favor Of "v6_networks". The "kvm_url" value will change periodically. It Is Not advised To cache this value. If you need To filter the list, review the parameters For this Function. Currently, only one filter at a time may be applied (SUBID, tag, label, main_ip).
        /// </summary>
        /// <returns>List of active or panding servers.</returns>
        public ServerResult GetServers()
        {
            var answer = new Dictionary<string, Server>();
            var httpResponse = Extensions.ApiClient.ApiExecute("server/list", _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
                answer = JsonConvert.DeserializeObject<Dictionary<string, Server>>((st ?? "") == "[]" ? "{}" : st);
            }

            return new ServerResult() { ApiResponse = httpResponse, Servers = answer };
        }

        /// <summary>
        /// Changes the virtual machine to a different application. All data will be permanently lost.
        /// </summary>
        /// <param name="SubId">Unique identifier for this subscription. These can be found using the GetServers() call.</param>
        /// <param name="AppId">Application to use. See AvailableApps() call.</param>
        /// <returns>No response, check HTTP result code.</returns>
        public ServerResult AppChange(int SubId, int AppId)
        {
            var dict = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("SUBID", SubId),
                new KeyValuePair<string, object>("APPID", AppId)
            };
            var answer = new Dictionary<string, Server>();
            var httpResponse = Extensions.ApiClient.ApiExecute("server/app_change", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
                answer = JsonConvert.DeserializeObject<Dictionary<string, Server>>((st ?? "") == "[]" ? "{}" : st);
            }

            return new ServerResult() { ApiResponse = httpResponse, Servers = answer };
        }

        /// <summary>
        /// Retrieves a list of applications to which a virtual machine can be changed. Always check against this list before trying to switch applications because it is not possible to switch between every application combination.
        /// </summary>
        /// <param name="SubId">Unique identifier for this subscription. These can be found using the GetServers() call.</param>
        /// <returns>List of available apps</returns>
        public ApplicationResult AppsAvailable(int SubId)
        {
            var answer = new ApplicationResult();
            var httpResponse = Extensions.ApiClient.ApiExecute("server/app_change_list?SUBID=" + SubId, "");
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
                answer.Applications = JsonConvert.DeserializeObject<Dictionary<string, Application>>(st);
            }

            return new ApplicationResult() { ApiResponse = httpResponse, Applications = answer.Applications };
        }

        /// <summary>
        /// Disables automatic backups On a server. Once disabled, backups can only be enabled again by customer support.
        /// </summary>
        /// <param name="SubId">Unique identifier for this subscription. These can be found using the GetServers() call.</param>
        /// <returns>No response, check HTTP result code.</returns>
        public BackupResult BackupDisable(int SubId)
        {
            var dict = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("SUBID", SubId)
            };
            var answer = new Dictionary<string, Backup>();
            var httpResponse = Extensions.ApiClient.ApiExecute("server/backup_disable", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
                answer = JsonConvert.DeserializeObject<Dictionary<string, Backup>>((st ?? "") == "[]" ? "{}" : st);
            }

            return new BackupResult() { ApiResponse = httpResponse, Backups = answer };
        }

        /// <summary>
        /// Enables automatic backups on a server.
        /// </summary>
        /// <param name="SubId">Unique identifier for this subscription. These can be found using the GetServers() call.</param>
        /// <returns>No response, check HTTP result code.</returns>
        public BackupResult BackupEnable(int SubId)
        {
            var dict = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("SUBID", SubId)
            };
            var answer = new Dictionary<string, Backup>();
            var httpResponse = Extensions.ApiClient.ApiExecute("server/backup_enable", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
                answer = JsonConvert.DeserializeObject<Dictionary<string, Backup>>((st ?? "") == "[]" ? "{}" : st);
            }

            return new BackupResult() { ApiResponse = httpResponse, Backups = answer };
        }

        /// <summary>
        /// Retrieves the backup schedule for a server. All time values are in UTC.
        /// </summary>
        /// <param name="SubId">Unique identifier for this subscription. These can be found using the GetServers() call.</param>
        /// <returns>No response, check HTTP result code.</returns>
        public ScheduleResult BackupScheduleGet(int SubId)
        {
            var dict = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("SUBID", SubId)
            };
            var answer = new Schedule();
            var httpResponse = Extensions.ApiClient.ApiExecute("server/backup_get_schedule", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
                answer = JsonConvert.DeserializeObject<Schedule>((st ?? "") == "[]" ? "{}" : st);
            }

            return new ScheduleResult() { ApiResponse = httpResponse, Schedule = answer };
        }

        /// <summary>
        /// Sets the backup schedule for a server. All time values are in UTC.
        /// </summary>
        /// <param name="SubId">Unique identifier for this subscription. These can be found using the GetServers() call.</param>
        /// <param name="Schedule">Schedule a backup object for a server</param>
        /// <returns>No response, check HTTP result code.</returns>
        public ScheduleResult BackupScheduleSet(int SubId, Schedule Schedule)
        {
            var dict = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("SUBID", SubId),
                new KeyValuePair<string, object>("cron_type", Schedule.CronType),
                new KeyValuePair<string, object>("hour", Schedule.Hour),
                new KeyValuePair<string, object>("dow", Schedule.DOW),
                new KeyValuePair<string, object>("dom", Schedule.DOM)
            };
            var answer = new Schedule();
            var httpResponse = Extensions.ApiClient.ApiExecute("server/backup_get_schedule", _ApiKey, dict, "POST");
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
                answer = JsonConvert.DeserializeObject<Schedule>((st ?? "") == "[]" ? "{}" : st);
            }

            return new ScheduleResult() { ApiResponse = httpResponse, Schedule = answer };
        }

        /// <summary>
        /// Get the bandwidth used by a virtual machine.
        /// </summary>
        /// <param name="SubId">Unique identifier for this subscription. These can be found using the GetServers() call.</param>
        /// <returns>Bandwidth used by a virtual machine day by day.</returns>
        public BandwidthResult BandwidthGet(int SubId)
        {
            var answer = new BandwidthResult();
            var httpResponse = Extensions.ApiClient.ApiExecute("server/bandwidth?SUBID=" + SubId, _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
                answer.BandWidth = JsonConvert.DeserializeObject<BandWidth>(st);
            }

            return new BandwidthResult() { ApiResponse = httpResponse, BandWidth = answer.BandWidth };
        }

        /// <summary>
        /// Create a new virtual machine. You will start being billed for this immediately. The response only contains the SUBID for the new machine. You should use v1/server/list to poll and wait for the machine to be created (as this does not happen instantly). In order to create a server using a snapshot, use OSID 164 and specify a SNAPSHOTID. Similarly, to create a server using an ISO use OSID 159 and specify an ISOID.
        /// </summary>
        /// <returns>List of active or panding servers.</returns>
        public ServerResult CreateServer()
        {
            var answer = new Dictionary<string, Server>();
            var httpResponse = Extensions.ApiClient.ApiExecute("server/list", _ApiKey);
            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
                answer = JsonConvert.DeserializeObject<Dictionary<string, Server>>((st ?? "") == "[]" ? "{}" : st);
            }

            return new ServerResult() { ApiResponse = httpResponse, Servers = answer };
        }
    }
}