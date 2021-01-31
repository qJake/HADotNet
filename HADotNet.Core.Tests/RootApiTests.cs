using HADotNet.Core.Clients;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace HADotNet.Core.Tests
{
    public class RootApiTests
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
        public async Task ShouldRetrieveRootApiMessage()
        {
            var client = ClientFactory.GetClient<RootApiClient>();

            var message = await client.GetStatusMessage();

            Assert.IsNotEmpty(message.Message);
            Assert.AreEqual("API running.", message.Message);
        }
    }
}