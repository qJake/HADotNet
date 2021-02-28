using System;
using System.Threading.Tasks;
using HADotNet.Core.Clients;
using HADotNet.Core.Tests.Infrastructure;
using NUnit.Framework;

namespace HADotNet.Core.Tests
{
    public class ServiceTests
    {
        private ServiceClient Client { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            var instance = new Uri(Environment.GetEnvironmentVariable("HADotNet:Tests:Instance"));
            var apiKey = Environment.GetEnvironmentVariable("HADotNet:Tests:ApiKey");

            ClientFactory.Initialize(instance, apiKey, DefaultHttpClientFactory.GetInstance());

            Client = ClientFactory.GetClient<ServiceClient>();
        }

        [Test]
        public async Task ShouldRetrieveServiceList()
        {
            var services = await Client.GetServices();

            Assert.IsNotNull(services);
            Assert.AreNotEqual(0, services.Count);
        }

        [Test]
        public async Task ShouldCallService()
        {
            var returnState = await Client.CallService("light.turn_on", new { entity_id = "light.sample_light" });

            Assert.IsNotNull(returnState);

            // Uncomment if you are actually running a test against a real entity that will return state data
            //Assert.AreNotEqual(0, returnState.Count);
        }

        [Test]
        public async Task ShouldCallServiceWithEntityId()
        {
            var returnState = await Client.CallServiceForEntities("light.turn_on", "light.my_light_1");

            Assert.IsNotNull(returnState);

            // Uncomment if you are actually running a test against a real entity that will return state data
            //Assert.AreNotEqual(0, returnState.Count);
        }

        [Test]
        public async Task ShouldCallServiceWithEntityIds()
        {
            var returnState = await Client.CallServiceForEntities("light.turn_on", "light.my_light_1", "light.my_light_2");

            Assert.IsNotNull(returnState);

            // Uncomment if you are actually running a test against a real entity that will return state data
            //Assert.AreNotEqual(0, returnState.Count);
        }
    }
}