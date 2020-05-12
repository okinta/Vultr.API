using Vultr.API;
using Xunit;

namespace Tests.Clients
{
    public class ServerClientTest
    {
        [Fact]
        public void TestGetServers()
        {
            var client = new VultrClient(Settings.Default.VultrApiKey);
            var servers = client.Server.GetServers();

            Assert.True(servers.Servers != null);
        }
    }
}
