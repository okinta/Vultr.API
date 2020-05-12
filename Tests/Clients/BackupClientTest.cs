using Vultr.API;
using Xunit;

namespace Tests.Clients
{
    public class BackupClientTest
    {
        [Fact]
        public void TestGetBackups()
        {
            var client = new VultrClient(Settings.Default.VultrApiKey);
            var backups = client.Backup.GetBackups();

            Assert.True(backups.Backups != null);
        }
    }
}
