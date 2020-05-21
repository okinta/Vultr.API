using MockHttp.Net;
using System;
using Vultr.API;

namespace Tests
{
    /// <summary>
    /// Describes methods to mock Vultr API requests.
    /// </summary>
    internal class MockVultrRequests : MockRequests
    {
        /// <summary>
        /// Gets the VultrPlatform instance that has its requests routed to the mock
        /// server.
        /// </summary>
        public VultrClient Client { get; }

        /// <summary>
        /// Instantiates a new instance. Starts the mock HTTP server.
        /// </summary>
        /// <param name="handlers"></param>
        /// <exception cref="ArgumentNullException">If <paramref name="handlers"/> is
        /// null.</exception>
        public MockVultrRequests(params HttpHandler[] handlers) :
            base(handlers)
        {
            Client = new VultrClient("abc123", Url);
        }
    }
}
