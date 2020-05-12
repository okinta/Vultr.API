using Vultr.API;
using Xunit;

namespace Tests.Clients
{
    public class ISOImageClientTest
    {
        [Fact]
        public void TestGetISOImages()
        {
            var client = new VultrClient(Settings.Default.VultrApiKey);
            var images = client.ISOImage.GetISOImages();

            Assert.True(images.ISOImages != null);
        }
    }
}
