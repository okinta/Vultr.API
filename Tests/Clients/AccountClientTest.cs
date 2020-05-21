using MockHttp.Net;
using Tests.Properties;
using Vultr.API;
using Xunit;

namespace Tests.Clients
{
    public class AccountClientTest
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
            using var requests = new MockVultrRequests(
                new HttpHandler(
                    "/account/info", Resources.AccountInfo));
            var account = requests.Client.Account.GetInfo();
            Assert.Equal("-5519.11", account.Account.balance);
            requests.AssertAllCalledOnce();
        }
    }
}
