using HADotNet.Core;
using HADotNet.Core.Clients;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Tests
{
    public class ServiceTests
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
        public async Task ShouldRetrieveServiceList()
        {
            var client = ClientFactory.GetClient<ServiceClient>();

            var services = await client.GetServices();

            Assert.IsNotNull(services);
            Assert.AreNotEqual(0, services.Count);
        }

        [Test]
        public async Task ShouldCallService()
        {
            var client = ClientFactory.GetClient<ServiceClient>();

            var returnState = await client.CallService("light.turn_on", new { entity_id = "light.sample_light" });

            Assert.IsNotNull(returnState);

            // Uncomment if you are actually running a test against a real entity that will return state data
            //Assert.AreNotEqual(0, returnState.Count);
        }
    }
}