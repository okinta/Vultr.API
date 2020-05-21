using MockHttp.Net;
using Tests.Properties;
using Vultr.API.Models;
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

        [Fact]
        public void TestMockGetStartupScripts()
        {
            using var requests = new MockVultrRequests(
                new HttpHandler(
                    "/startupscript/list", Resources.StartupScripts));
            var scripts = requests.Client.StartupScript.GetStartupScripts();
            Assert.Equal(2, scripts.StartupScripts.Count);
            Assert.Equal("3", scripts.StartupScripts["3"].SCRIPTID);
            Assert.Equal("5", scripts.StartupScripts["5"].SCRIPTID);
            Assert.Equal("pxe", scripts.StartupScripts["5"].type);
            requests.AssertAllCalledOnce();
        }

        [Fact]
        public void TestCreateStartupScript()
        {
            using var requests = new MockVultrRequests(
                new HttpHandler(
                    "/startupscript/create",
                    "name=myscript&script=this+is+my+script&type=pxe",
                    Resources.CreateStartupScript));
            var result = requests.Client.StartupScript.CreateStartupScript(
                "myscript", "this is my script", ScriptType.pxe);
            Assert.Equal("5", result.StartupScript.SCRIPTID);
            requests.AssertAllCalledOnce();
        }
    }
}
