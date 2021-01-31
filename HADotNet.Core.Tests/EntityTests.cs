using HADotNet.Core;
using HADotNet.Core.Clients;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HADotNet.Core.Tests
{
    public class EntityTests
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
        public async Task ShouldRetrieveEntityList()
        {
            var client = ClientFactory.GetClient<EntityClient>();

            var entities = await client.GetEntities();

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