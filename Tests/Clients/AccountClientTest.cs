using System;
using Vultr.API;
using Xunit;

namespace Tests.Clients
{
    public class AccountClientTest
    {
        private static string ApiKey
        {
            get
            {
                var key = Settings.Default.VultrApiKey;

                if (string.IsNullOrEmpty(key))
                {

                    throw new InvalidOperationException("API key must be set");
                }

                return key;
            }
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
