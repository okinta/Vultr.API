using MockHttpServer;
using System.Collections.Generic;
using Vultr.API;

namespace Tests.Clients
{
    public abstract class BaseClientTest
    {
        protected const int TestPort = 8451;
        protected const string TestURL = "http://localhost:8451/";

        protected VultrClient Client { get; } = new VultrClient("abc123", TestURL);

        protected MockServer GetMockServer(IEnumerable<MockHttpHandler> requestHandlers)
        {
            return new MockServer(TestPort, requestHandlers);
        }
    }
}
