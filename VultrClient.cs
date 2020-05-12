using Microsoft.VisualBasic.CompilerServices;
using System.Net;
using Vultr.API.Clients;

namespace Vultr.API
{
    public class VultrClient
    {
        /// <summary>
        /// Account Client for Account operations
        /// </summary>
        /// <returns>Account and HTTP Response</returns>
        public AccountClient Account { get; set; }

        /// <summary>
        /// Application operations
        /// </summary>
        /// <returns>Application and HTTP Response</returns>
        public ApplicationClient Application { get; set; }

        /// <summary>
        /// Auth operations
        /// </summary>
        /// <returns>Auth and HTTP Response</returns>
        public AuthClient Auth { get; set; }

        /// <summary>
        /// Backup operations
        /// </summary>
        /// <returns>Backup and HTTP Response</returns>
        public BackupClient Backup { get; set; }

        /// <summary>
        /// Block operations
        /// </summary>
        /// <returns>Block and HTTP Response</returns>
        public BlockClient Block { get; set; }

        /// <summary>
        /// DNS operations
        /// </summary>
        /// <returns>DNS and HTTP Response</returns>
        public DNSClient DNS { get; set; }

        /// <summary>
        /// Firewall operations
        /// </summary>
        /// <returns>Firewall and HTTP Response</returns>
        public FirewallClient Firewall { get; set; }

        /// <summary>
        /// ISO Image operations
        /// </summary>
        /// <returns>ISO Image and HTTP Response</returns>
        public ISOImageClient ISOImage { get; set; }

        /// <summary>
        /// Network operations
        /// </summary>
        /// <returns>Network and HTTP Response</returns>
        public NetworkClient Network { get; set; }

        /// <summary>
        /// Plan operations
        /// </summary>
        /// <returns>Plan and HTTP Response</returns>
        public PlanClient Plan { get; set; }

        /// <summary>
        /// Region operations
        /// </summary>
        /// <returns>Region and HTTP Response</returns>
        public RegionClient Region { get; set; }

        /// <summary>
        /// ReservedIP operations
        /// </summary>
        /// <returns>ReservedIP and HTTP Response</returns>
        public ReservedIPClient ReservedIP { get; set; }

        /// <summary>
        /// Server operations
        /// </summary>
        /// <returns>Server and HTTP Response</returns>
        public ServerClient Server { get; set; }

        /// <summary>
        /// Snapshot operations
        /// </summary>
        /// <returns>Snapshot and HTTP Response</returns>
        public SnapshotClient Snapshot { get; set; }

        /// <summary>
        /// SSHKey operations
        /// </summary>
        /// <returns>SSHKey and HTTP Response</returns>
        public SSHKeyClient SSHKey { get; set; }

        /// <summary>
        /// Startup Script operations
        /// </summary>
        /// <returns>StartupScript and HTTP Response</returns>
        public StartupScriptClient StartupScript { get; set; }

        /// <summary>
        /// Operating system operations
        /// </summary>
        /// <returns>Operating system and HTTP Response</returns>
        public OperatingSystemClient OperatingSystem { get; set; }

        /// <summary>
        /// User operations
        /// </summary>
        /// <returns>Users and HTTP Response</returns>
        public UserClient User { get; set; }

        public static readonly string VultrApiUrl = "https://api.vultr.com/v1/";

        public VultrClient(string ApiKey)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)Conversions.ToInteger(3072);
            ServicePointManager.DefaultConnectionLimit = 9999;
            Account = new AccountClient(ApiKey);
            Application = new ApplicationClient(ApiKey);
            Auth = new AuthClient(ApiKey);
            Backup = new BackupClient(ApiKey);
            Block = new BlockClient(ApiKey);
            DNS = new DNSClient(ApiKey);
            Firewall = new FirewallClient(ApiKey);
            ISOImage = new ISOImageClient(ApiKey);
            Network = new NetworkClient(ApiKey);
            OperatingSystem = new OperatingSystemClient(ApiKey);
            Plan = new PlanClient(ApiKey);
            Region = new RegionClient(ApiKey);
            ReservedIP = new ReservedIPClient(ApiKey);
            Server = new ServerClient(ApiKey);
            Snapshot = new SnapshotClient(ApiKey);
            SSHKey = new SSHKeyClient(ApiKey);
            StartupScript = new StartupScriptClient(ApiKey);
            User = new UserClient(ApiKey);
        }
    }
}