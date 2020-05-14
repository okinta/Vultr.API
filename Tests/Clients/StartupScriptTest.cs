using MockHttpServer;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Tests.Properties;
using Vultr.API.Models;
using Vultr.API;
using Xunit;

namespace Tests.Clients
{
    public class StartupScriptTest : BaseClientTest
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
            using var _ = GetMockServer(new List<MockHttpHandler>()
            {
                new MockHttpHandler("/startupscript/list", "GET", (req, rsp, prm) =>
                    Resources.StartupScripts)
            });
            var scripts = Client.StartupScript.GetStartupScripts();
            Assert.Equal(2, scripts.StartupScripts.Count);
            Assert.Equal("3", scripts.StartupScripts["3"].SCRIPTID);
            Assert.Equal("5", scripts.StartupScripts["5"].SCRIPTID);
            Assert.Equal("pxe", scripts.StartupScripts["5"].type);
        }

        [Fact]
        public void TestCreateStartupScript()
        {
            using var _ = GetMockServer(new List<MockHttpHandler>()
            {
                new MockHttpHandler("/startupscript/create", "POST", CreateStartupScript)
            });
            var result = Client.StartupScript.CreateStartupScript(
                "myscript", "this is my script", ScriptType.pxe);
            Assert.Equal("5", result.StartupScript.SCRIPTID);
        }

        private string CreateStartupScript(
            HttpListenerRequest req,
            HttpListenerResponse rsp,
            Dictionary<string, string> prm)
        {
            using var reader = new StreamReader(req.InputStream);
            Assert.Equal(
                "name=myscript&script=this+is+my+script&type=pxe",
                reader.ReadToEnd());

            return Resources.CreateStartupScript;
        }
    }
}
