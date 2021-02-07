using HADotNet.Core;
using HADotNet.Core.Clients;
using HADotNet.Entities.Models;
using HADotNet.Entities.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HADotNet.Entities.Tests.Entities
{
    public class LightTest
    {
        private const string MY_LIGHT = "my_light";

        [SetUp]
        public void Setup()
        {
            var instance = new Uri(Environment.GetEnvironmentVariable("HADotNet:Tests:Instance"));
            var apiKey = Environment.GetEnvironmentVariable("HADotNet:Tests:ApiKey");

            ClientFactory.Initialize(instance, apiKey);
        }

        [Test]
        public async Task TurnOn_ShouldTurnLightOn()
        {
            var statesClient = ClientFactory.GetClient<StatesClient>();
            var entityClient = ClientFactory.GetClient<EntityClient>();

            var entitiesService = new EntitiesService(entityClient, statesClient);

            var light = await entitiesService.GetEntity<Light>(MY_LIGHT);

            await light.TurnOn();

            Thread.Sleep(5000);

            await light.TurnOff();
        }
    }
}
