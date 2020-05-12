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

            Assert.True(float.TryParse(account.Account.Balance, out float _));
        }
    }
}
