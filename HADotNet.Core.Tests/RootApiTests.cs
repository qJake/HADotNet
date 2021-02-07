using System;
using System.Threading.Tasks;
using HADotNet.Core.Clients;
using HADotNet.Core.Tests.Infrastructure;
using NUnit.Framework;

namespace HADotNet.Core.Tests
{
    public class RootApiTests
    {
        private RootApiClient Client { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            var instance = new Uri(Environment.GetEnvironmentVariable("HADotNet:Tests:Instance"));
            var apiKey = Environment.GetEnvironmentVariable("HADotNet:Tests:ApiKey");

            ClientFactory.Initialize(instance, apiKey, DefaultHttpClientFactory.GetInstance());

            Client = ClientFactory.GetClient<RootApiClient>();
        }

        [Test]
        public async Task ShouldRetrieveRootApiMessage()
        {
            var message = await Client.GetStatusMessage();

            Assert.IsNotEmpty(message.Message);
            Assert.AreEqual("API running.", message.Message);
        }
    }
}