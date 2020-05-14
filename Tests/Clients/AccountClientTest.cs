using MockHttpServer;
using System.Collections.Generic;
using Tests.Properties;
using Vultr.API;
using Xunit;

namespace Tests.Clients
{
    public class AccountClientTest
    {
        private const int TestPort = 8451;
        private const string TestURL = "http://localhost:8451/";

        protected VultrClient Client { get; } = new VultrClient("abc123", TestURL);

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
            var requestHandlers = new List<MockHttpHandler>()
            {
                new MockHttpHandler("/account/info", "GET", (req, rsp, prm) =>
                    Resources.AccountInfo)
            };

            using (new MockServer(TestPort, requestHandlers))
            {
                var account = Client.Account.GetInfo();

                Assert.Equal("-5519.11", account.Account.balance);
            }
        }
    }
}
