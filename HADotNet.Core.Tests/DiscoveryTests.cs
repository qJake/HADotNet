using HADotNet.Core;
using HADotNet.Core.Clients;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Tests
{
    public class DiscoveryTests
    {
        private Uri Instance { get; set; }
        private string ApiKey { get; set; }

        [SetUp]
        public void Setup()
        {
            Instance = new Uri(Environment.GetEnvironmentVariable("HADotNet:Tests:Instance"));
            ApiKey = Environment.GetEnvironmentVariable("HADotNet:Tests:ApiKey");

            ClientFactory.Initialize(Instance, ApiKey);
        }

        [Test]
        public async Task ShouldRetrieveDiscoveryInfo()
        {
            var client = ClientFactory.GetClient<DiscoveryClient>();

            var discovery = await client.GetDiscoveryInfo();

            Assert.IsNotNull(discovery);
            Assert.IsNotEmpty(discovery.LocationName);
        }
    }
}