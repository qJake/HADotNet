using System;
using System.Threading.Tasks;
using NUnit.Framework;
using HADotNet.Core;
using HADotNet.Core.Clients;
using HADotNet.Entities.Models;

namespace HADotNet.Entities.Tests.Models
{
    public class ClimateTest
    {
        private const string MY_CLIMATE = "my_climate";

        [SetUp]
        public void Setup()
        {
            var instance = new Uri(Environment.GetEnvironmentVariable("HADotNet:Tests:Instance"));
            var apiKey = Environment.GetEnvironmentVariable("HADotNet:Tests:ApiKey");

            ClientFactory.Initialize(instance, apiKey);
        }

        [Test]
        public async Task SetHvacMode_ShouldSetHvacMode()
        {
            var entityClient = ClientFactory.GetClient<EntityClient>();
            var statesClient = ClientFactory.GetClient<StatesClient>();

            var entitiesService = new EntitiesService(entityClient, statesClient);

            var climate = await entitiesService.GetEntity<Climate>(MY_CLIMATE);

            await climate.SetHvacMode("auto");

            Assert.AreEqual("auto", climate.HvacAction);
        }
    }
}
