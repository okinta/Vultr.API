using Vultr.API;
using Xunit;

namespace Tests.Clients
{
    public class OperatingSystemClientTest
    {
        [Fact]
        public void TestGetOperatingSystems()
        {
            var client = new VultrClient(Settings.Default.VultrApiKey);
            var systems = client.OperatingSystem.GetOperatingSystems();

            Assert.NotNull(systems.OperatingSystems);
            Assert.Contains(
                systems.OperatingSystems,
                system => system.Value.name == "Debian 10 x64 (buster)");
        }
    }
}
