using System.Linq;
using Vultr.API;
using Xunit;

namespace Tests.Clients
{
    public class ApplicationsClientTest
    {
        [Fact]
        public void TestGetApplications()
        {
            var client = new VultrClient(Settings.Default.VultrApiKey);
            var apps = client.Application.GetApplications();

            var app = apps.Applications.Single(app => app.Value.Name == "WordPress");
            Assert.Equal("WordPress", app.Value.Name);
        }
    }
}
