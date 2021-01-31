using HADotNet.Core;
using HADotNet.Core.Clients;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace HADotNet.Core.Tests
{
    public class EventTests
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
        public async Task ShouldRetrieveEventList()
        {
            var client = ClientFactory.GetClient<EventClient>();

            var events = await client.GetEvents();

            Assert.IsNotNull(events);
            Assert.AreNotEqual(0, events.Count);
        }
    }
}