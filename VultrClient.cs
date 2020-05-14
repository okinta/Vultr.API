using System;
using Vultr.API.Clients;

namespace Vultr.API
{
    public class VultrClient
    {
        /// <summary>
        /// Account Client for Account operations
        /// </summary>
        /// <returns>Account and HTTP Response</returns>
        public AccountClient Account { get; }

        /// <summary>
        /// Application operations
        /// </summary>
        /// <returns>Application and HTTP Response</returns>
        public ApplicationClient Application { get; }

        /// <summary>
        /// Auth operations
        /// </summary>
        /// <returns>Auth and HTTP Response</returns>
        public AuthClient Auth { get; }

        /// <summary>
        /// Backup operations
        /// </summary>
        /// <returns>Backup and HTTP Response</returns>
        public BackupClient Backup { get; }

        /// <summary>
        /// Block operations
        /// </summary>
        /// <returns>Block and HTTP Response</returns>
        public BlockClient Block { get; }

        /// <summary>
        /// DNS operations
        /// </summary>
        /// <returns>DNS and HTTP Response</returns>
        public DNSClient DNS { get; }

        /// <summary>
        /// Firewall operations
        /// </summary>
        /// <returns>Firewall and HTTP Response</returns>
        public FirewallClient Firewall { get; }

        /// <summary>
        /// ISO Image operations
        /// </summary>
        /// <returns>ISO Image and HTTP Response</returns>
        public ISOImageClient ISOImage { get; }

        /// <summary>
        /// Network operations
        /// </summary>
        /// <returns>Network and HTTP Response</returns>
        public NetworkClient Network { get; }

        /// <summary>
        /// Plan operations
        /// </summary>
        /// <returns>Plan and HTTP Response</returns>
        public PlanClient Plan { get; }

        /// <summary>
        /// Region operations
        /// </summary>
        /// <returns>Region and HTTP Response</returns>
        public RegionClient Region { get; }

        /// <summary>
        /// ReservedIP operations
        /// </summary>
        /// <returns>ReservedIP and HTTP Response</returns>
        public ReservedIPClient ReservedIP { get; }

        /// <summary>
        /// Server operations
        /// </summary>
        /// <returns>Server and HTTP Response</returns>
        public ServerClient Server { get; }

        /// <summary>
        /// Snapshot operations
        /// </summary>
        /// <returns>Snapshot and HTTP Response</returns>
        public SnapshotClient Snapshot { get; }

        /// <summary>
        /// SSHKey operations
        /// </summary>
        /// <returns>SSHKey and HTTP Response</returns>
        public SSHKeyClient SSHKey { get; }

        /// <summary>
        /// Startup Script operations
        /// </summary>
        /// <returns>StartupScript and HTTP Response</returns>
        public StartupScriptClient StartupScript { get; }

        /// <summary>
        /// Operating system operations
        /// </summary>
        /// <returns>Operating system and HTTP Response</returns>
        public OperatingSystemClient OperatingSystem { get; }
        /// <summary>
        /// User operations
        /// </summary>
        /// <returns>Users and HTTP Response</returns>
        public UserClient User { get; }

        private const string VultrApiURL = "https://api.vultr.com/v1/";

        /// <summary>
        /// Instantiates a new instance.
        /// </summary>
        /// <param name="apiKey">The API key to use to communicate with the Vultr
        /// API.</param>
        /// <param name="apiURL">The optional Vultr API URL to use. Set this if you want
        /// to override the default endpoint (e.g. for testing).</param>
        /// <exception cref="ArgumentNullException">If <paramref name="apiKey"/> is null
        /// or empty.</exception>
        public VultrClient(string apiKey, string apiURL = VultrApiURL)
        {
            if (string.IsNullOrEmpty(apiKey))
                throw new ArgumentNullException("apiKey", "apiKey must not be null");

            Account = new AccountClient(apiKey, apiURL);
            Application = new ApplicationClient(apiKey, apiURL);
            Auth = new AuthClient(apiKey, apiURL);
            Backup = new BackupClient(apiKey, apiURL);
            Block = new BlockClient(apiKey, apiURL);
            DNS = new DNSClient(apiKey, apiURL);
            Firewall = new FirewallClient(apiKey, apiURL);
            ISOImage = new ISOImageClient(apiKey, apiURL);
            Network = new NetworkClient(apiKey, apiURL);
            OperatingSystem = new OperatingSystemClient(apiKey, apiURL);
            Plan = new PlanClient(apiKey, apiURL);
            Region = new RegionClient(apiKey, apiURL);
            ReservedIP = new ReservedIPClient(apiKey, apiURL);
            Server = new ServerClient(apiKey, apiURL);
            Snapshot = new SnapshotClient(apiKey, apiURL);
            SSHKey = new SSHKeyClient(apiKey, apiURL);
            StartupScript = new StartupScriptClient(apiKey, apiURL);
            User = new UserClient(apiKey, apiURL);
        }
    }
}