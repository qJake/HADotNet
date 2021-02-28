using System;
using System.Threading.Tasks;
using HADotNet.Core.Clients;
using HADotNet.Core.Tests.Infrastructure;
using NUnit.Framework;

namespace HADotNet.Core.Tests
{
    public class StatsTests
    {
        private StatsClient Client { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            var instance = new Uri(Environment.GetEnvironmentVariable("HADotNet:Tests:Instance"));
            var apiKey = Environment.GetEnvironmentVariable("HADotNet:Tests:ApiKey");

            ClientFactory.Initialize(instance, apiKey, DefaultHttpClientFactory.GetInstance());

            Client = ClientFactory.GetClient<StatsClient>();
        }

        [Test]
        public async Task ShouldRetrieveSupervisorStats()
        {
            var stats = await Client.GetSupervisorStats();

            Assert.AreEqual("ok", stats.Result);
            Assert.IsNotNull(stats.Data);
        }

        [Test]
        public async Task ShouldRetrieveCoreStats()
        {
            var stats = await Client.GetCoreStats();

            Assert.AreEqual("ok", stats.Result);
            Assert.IsNotNull(stats.Data);
        }
    }
}
