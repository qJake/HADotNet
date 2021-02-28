using System;
using System.Threading.Tasks;
using HADotNet.Core.Clients;
using HADotNet.Core.Tests.Infrastructure;
using NUnit.Framework;

namespace HADotNet.Core.Tests
{
    public class DiscoveryTests
    {
        private DiscoveryClient Client { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            var instance = new Uri(Environment.GetEnvironmentVariable("HADotNet:Tests:Instance"));
            var apiKey = Environment.GetEnvironmentVariable("HADotNet:Tests:ApiKey");

            ClientFactory.Initialize(instance, apiKey, DefaultHttpClientFactory.GetInstance());

            Client = ClientFactory.GetClient<DiscoveryClient>();
        }

        [Test]
        public async Task ShouldRetrieveDiscoveryInfo()
        {
            var discovery = await Client.GetDiscoveryInfo();

            Assert.IsNotNull(discovery);
            Assert.IsNotEmpty(discovery.LocationName);
        }
    }
}