using Vultr.API;
using Xunit;

namespace Tests.Clients
{
    public class StartupScriptTest
    {
        [Fact]
        public void TestGetStartupScripts()
        {
            var client = new VultrClient(Settings.Default.VultrApiKey);
            var scripts = client.StartupScript.GetStartupScripts();
            Assert.True(scripts.StartupScripts.Count > 0);
        }
    }
}
