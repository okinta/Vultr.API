using System.Configuration;
using Vultr.API;
using Xunit;

namespace Tests.Clients
{
    public class AccountClientTest
    {
        private static string ApiKey
        {
            get { return ConfigurationManager.AppSettings["ApiKey"]; }
        }

        [Fact]
        public void TestGetInfo()
        {
            var client = new VultrClient(ApiKey);
            var account = client.Account.GetInfo();

            Assert.True(int.TryParse(account.Account.Balance, out int _));
        }
    }
}
