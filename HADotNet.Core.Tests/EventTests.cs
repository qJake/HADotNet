using System;
using System.Threading.Tasks;
using HADotNet.Core.Clients;
using HADotNet.Core.Tests.Infrastructure;
using NUnit.Framework;

namespace HADotNet.Core.Tests
{
    public class EventTests
    {
        private EventClient Client { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            var instance = new Uri(Environment.GetEnvironmentVariable("HADotNet:Tests:Instance"));
            var apiKey = Environment.GetEnvironmentVariable("HADotNet:Tests:ApiKey");

            ClientFactory.Initialize(instance, apiKey, DefaultHttpClientFactory.GetInstance());

            Client = ClientFactory.GetClient<EventClient>();
        }

        [Test]
        public async Task ShouldRetrieveEventList()
        {
            var events = await Client.GetEvents();

            Assert.IsNotNull(events);
            Assert.AreNotEqual(0, events.Count);
        }
    }
}