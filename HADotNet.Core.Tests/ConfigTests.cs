using System;
using System.Threading.Tasks;
using HADotNet.Core.Clients;
using HADotNet.Core.Tests.Infrastructure;
using NUnit.Framework;

namespace HADotNet.Core.Tests
{
    public class ConfigTests
    {
        private ConfigClient Client { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            var instance = new Uri(Environment.GetEnvironmentVariable("HADotNet:Tests:Instance"));
            var apiKey = Environment.GetEnvironmentVariable("HADotNet:Tests:ApiKey");

            ClientFactory.Initialize(instance, apiKey, DefaultHttpClientFactory.GetInstance());

            Client = ClientFactory.GetClient<ConfigClient>();
        }

        [Test]
        public async Task ShouldRetrieveConfiguration()
        {
            var config = await Client.GetConfiguration();

            Assert.IsNotNull(config);
            Assert.IsNotNull(config.UnitSystem);
            Assert.AreNotEqual(0, config.Components.Count);

        }
    }
}