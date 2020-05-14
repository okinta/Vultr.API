using MockHttpServer;
using System.Collections.Generic;
using Tests.Properties;
using Vultr.API;
using Xunit;

namespace Tests.Clients
{
    public class AccountClientTest : BaseClientTest
    {
        [Fact]
        public void TestGetInfo()
        {
            var client = new VultrClient(Settings.Default.VultrApiKey);
            var account = client.Account.GetInfo();

            Assert.True(float.TryParse(account.Account.balance, out float _));
        }

        [Fact]
        public void TestMockGetInfo()
        {
            using var _ = GetMockServer(new List<MockHttpHandler>()
            {
                new MockHttpHandler("/account/info", "GET", (req, rsp, prm) =>
                    Resources.AccountInfo)
            });
            var account = Client.Account.GetInfo();
            Assert.Equal("-5519.11", account.Account.balance);
        }
    }
}
