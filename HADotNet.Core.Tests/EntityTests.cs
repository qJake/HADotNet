using System;
using System.Linq;
using System.Threading.Tasks;
using HADotNet.Core.Clients;
using HADotNet.Core.Tests.Infrastructure;
using NUnit.Framework;

namespace HADotNet.Core.Tests
{
    public class EntityTests
    {
        private EntityClient Client { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            var instance = new Uri(Environment.GetEnvironmentVariable("HADotNet:Tests:Instance"));
            var apiKey = Environment.GetEnvironmentVariable("HADotNet:Tests:ApiKey");

            ClientFactory.Initialize(instance, apiKey, DefaultHttpClientFactory.GetInstance());

            Client = ClientFactory.GetClient<EntityClient>();
        }

        [Test]
        public async Task ShouldRetrieveEntityList()
        {
            var entities = await Client.GetEntities();

            Assert.IsNotNull(entities);
            Assert.AreNotEqual(0, entities.Count());
        }

        [Test]
        public async Task ShouldRetrieveEntityListWithDomainFilter()
        {
            var client = ClientFactory.GetClient<EntityClient>();

            var entities = await client.GetEntities("light");

            Assert.IsNotNull(entities);
            Assert.AreNotEqual(0, entities.Count());
        }
    }
}