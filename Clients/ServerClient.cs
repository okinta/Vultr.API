using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net;
using Vultr.API.Models.Responses;

namespace Vultr.API.Clients
{
    public class ServerClient
    {
        private string ApiKey { get; }

        public ServerClient(string apiKey)
        {
            ApiKey = apiKey;
        }

        /// <summary>
        /// List all active or pending virtual machines on the current account. The "status" field represents the status of the subscription And will be one of pending | active | suspended | closed. If the status Is "active", you can check "power_status" to determine if the VPS Is powered on Or Not. When status Is "active", you may also use "server_state" for a more detailed status of: none | locked | installingbooting | isomounting | ok. The API does Not provide any way To determine If the initial installation has completed Or Not. The "v6_network", "v6_main_ip", And "v6_network_size" fields are deprecated In favor Of "v6_networks". The "kvm_url" value will change periodically. It Is Not advised To cache this value. If you need To filter the list, review the parameters For this Function. Currently, only one filter at a time may be applied (SUBID, tag, label, main_ip).
        /// </summary>
        /// <returns>List of active or panding servers.</returns>
        public ServerResult GetServers()
        {
            var answer = new Dictionary<string, Server>();
            var httpResponse = Extensions.ApiClient.ApiExecute("server/list", ApiKey);
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
            var httpResponse = Extensions.ApiClient.ApiExecute("server/app_change", ApiKey, dict, "POST");
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
            var httpResponse = Extensions.ApiClient.ApiExecute("server/backup_disable", ApiKey, dict, "POST");
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
            var httpResponse = Extensions.ApiClient.ApiExecute("server/backup_enable", ApiKey, dict, "POST");
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
            var httpResponse = Extensions.ApiClient.ApiExecute("server/backup_get_schedule", ApiKey, dict, "POST");
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
                new KeyValuePair<string, object>("cron_type", Schedule.cron_type),
                new KeyValuePair<string, object>("hour", Schedule.hour),
                new KeyValuePair<string, object>("dow", Schedule.dow),
                new KeyValuePair<string, object>("dom", Schedule.dom)
            };
            var answer = new Schedule();
            var httpResponse = Extensions.ApiClient.ApiExecute("server/backup_get_schedule", ApiKey, dict, "POST");
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
            var httpResponse = Extensions.ApiClient.ApiExecute("server/bandwidth?SUBID=" + SubId, ApiKey);

            if ((int)httpResponse.StatusCode == 200)
            {
                using var streamReader = new StreamReader(httpResponse.GetResponseStream());
                string st = streamReader.ReadToEnd();
                answer.BandWidth = JsonConvert.DeserializeObject<BandWidth>(st);
            }

            return new BandwidthResult() { ApiResponse = httpResponse, BandWidth = answer.BandWidth };
        }

        /// <summary>
        /// Create a new virtual machine. You will start being billed for this
        /// immediately. The response only contains the SUBID for the new machine.
        ///
        /// To determine that a server is ready for use, you may poll
        /// /v1/server/list?SUBID=<SUBID> and check that the "status" field is set to
        /// "active", then test your OS login with SSH (Linux) or RDP (Windows).
        ///
        /// In order to create a server using a snapshot, use OSID 164 and specify a
        /// SNAPSHOTID. Similarly, to create a server using an ISO use OSID 159 and
        /// specify an ISOID.
        /// </summary>
        /// <param name="DCID">Location to create this virtual machine in. See
        /// v1/regions/list.</param>
        /// <param name="VPSPLANID">Plan to use when creating this virtual machine. See
        /// v1/plans/list.</param>
        /// <param name="OSID">Operating system to use. See v1/os/list.</param>
        /// <param name="ipxe_chain_url">If you've selected the 'custom' operating
        /// system, this can be set to chainload the specified URL on bootup, via
        /// iPXE.</param>
        /// <param name="ISOID">If you've selected the 'custom' operating system, this
        /// is the ID of a specific ISO to mount during the deployment.</param>
        /// <param name="SCRIPTID">If you've not selected a 'custom' operating system,
        /// this can be the SCRIPTID of a startup script to execute on boot. See
        /// v1/startupscript/list.</param>
        /// <param name="SNAPSHOTID">If you've selected the 'snapshot' operating system,
        /// this should be the SNAPSHOTID (see v1/snapshot/list) to restore for the
        /// initial installation.</param>
        /// <param name="enable_ipv6">If yes, an IPv6 subnet will be assigned to the
        /// machine (where available).</param>
        /// <param name="enable_private_network">If yes, private networking support
        /// will be added to the new server.</param>
        /// <param name="NETWORKID">List of private networks to attach to this server.
        /// Use either this field or enable_private_network, not both.</param>
        /// <param name="label">This is a text label that will be shown in the control
        /// panel.</param>
        /// <param name="SSHKEYID">List of SSH keys to apply to this server on install
        /// (only valid for Linux/FreeBSD). See v1/sshkey/list. Separate keys with
        /// commas.</param>
        /// <param name="auto_backups">If yes, automatic backups will be enabled for
        /// this server (these have an extra charge associated with them).</param>
        /// <param name="APPID">If launching an application (OSID 186), this is the
        /// APPID to launch. See v1/app/list.</param>
        /// <param name="userdata">Base64 encoded user-data</param>
        /// <param name="notify_activate">If yes, an activation email will be sent
        /// when the server is ready.</param>
        /// <param name="ddos_protection">If yes, DDOS protection will be enabled on
        /// the subscription (there is an additional charge for this).</param>
        /// <param name="reserved_ip_v4">IP address of the floating IP to use as the
        /// main IP of this server.</param>
        /// <param name="hostname">The hostname to assign to this server.</param>
        /// <param name="tag">The tag to assign to this server.</param>
        /// <param name="FIREWALLGROUPID">The firewall group to assign to this server.
        /// See /v1/firewall/group_list.</param>
        /// <returns>The newly created server.</returns>
        public CreateServerResult CreateServer(
            int DCID,
            int VPSPLANID,
            int OSID,
            string ipxe_chain_url = null,
            string ISOID = null,
            int? SCRIPTID = null,
            string SNAPSHOTID = null,
            bool? enable_ipv6 = null,
            bool? enable_private_network = null,
            string NETWORKID = null,
            string label = null,
            string SSHKEYID = null,
            string auto_backups = null,
            int? APPID = null,
            string userdata = null,
            bool? notify_activate = null,
            bool? ddos_protection = null,
            string reserved_ip_v4 = null,
            string hostname = null,
            string tag = null,
            string FIREWALLGROUPID = null
        )
        {
            var args = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("DCID", DCID),
                new KeyValuePair<string, object>("VPSPLANID", VPSPLANID),
                new KeyValuePair<string, object>("OSID", OSID),
                new KeyValuePair<string, object>("ipxe_chain_url", ipxe_chain_url),
                new KeyValuePair<string, object>("ISOID", ISOID),
                new KeyValuePair<string, object>("SCRIPTID", SCRIPTID),
                new KeyValuePair<string, object>("SNAPSHOTID", SNAPSHOTID),
                new KeyValuePair<string, object>("enable_ipv6", enable_ipv6),
                new KeyValuePair<string, object>("enable_private_network", enable_private_network),
                new KeyValuePair<string, object>("NETWORKID", NETWORKID),
                new KeyValuePair<string, object>("label", label),
                new KeyValuePair<string, object>("SSHKEYID", SSHKEYID),
                new KeyValuePair<string, object>("auto_backups", auto_backups),
                new KeyValuePair<string, object>("APPID", APPID),
                new KeyValuePair<string, object>("userdata", userdata),
                new KeyValuePair<string, object>("notify_activate", notify_activate),
                new KeyValuePair<string, object>("ddos_protection", ddos_protection),
                new KeyValuePair<string, object>("reserved_ip_v4", reserved_ip_v4),
                new KeyValuePair<string, object>("hostname", hostname),
                new KeyValuePair<string, object>("tag", tag),
                new KeyValuePair<string, object>("FIREWALLGROUPID", FIREWALLGROUPID)
            };

            var httpResponse = Extensions.ApiClient.ApiExecute(
                "server/create", ApiKey, args, "POST");

            string content;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                content = streamReader.ReadToEnd();
            }

            if (httpResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpRequestException(
                    string.Format("{0}: {1}", httpResponse.StatusCode, content));
            }

            var answer = JsonConvert.DeserializeObject<CreateServer>((content ?? "") == "[]" ? "{}" : content);

            return new CreateServerResult() { ApiResponse = httpResponse, Server = answer };
        }
    }
}