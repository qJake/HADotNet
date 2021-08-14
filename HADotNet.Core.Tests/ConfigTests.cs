using HADotNet.Core.Clients;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace HADotNet.Core.Tests
{
    public class ConfigTests
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
        public async Task ShouldRetrieveConfiguration()
        {
            var client = ClientFactory.GetClient<ConfigClient>();

            var config = await client.GetConfiguration();

            Assert.IsNotNull(config);
            Assert.IsNotNull(config.UnitSystem);
            Assert.AreNotEqual(0, config.Components.Count);

        }

        [Test]
        public async Task ShouldCheckConfig()
        {
            var client = ClientFactory.GetClient<ConfigClient>();

            var config = await client.CheckConfiguration();

            Assert.IsNotNull(config);
            Assert.IsNotNull(config.Result);
            Assert.AreEqual("valid", config.Result);

        }
    }
}