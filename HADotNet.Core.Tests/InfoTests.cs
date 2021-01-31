using System;
using System.Threading.Tasks;
using HADotNet.Core.Clients;
using NUnit.Framework;

namespace HADotNet.Core.Tests
{
    public class InfoTests
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
        public async Task ShouldRetrieveSupervisorInfo()
        {
            var client = ClientFactory.GetClient<InfoClient>();

            var info = await client.GetSupervisorInfo();

            Assert.AreEqual("ok", info.Result);
            Assert.IsNotNull(info.Data);
            Assert.IsNotNull(info.Data.Version);
        }

        [Test]
        public async Task ShouldRetrieveHostInfo()
        {
            var client = ClientFactory.GetClient<InfoClient>();

            var info = await client.GetHostInfo();

            Assert.AreEqual("ok", info.Result);
            Assert.IsNotNull(info.Data);
            Assert.IsNotNull(info.Data.OperatingSystem);
        }

        [Test]
        public async Task ShouldRetrieveCoreInfo()
        {
            var client = ClientFactory.GetClient<InfoClient>();

            var info = await client.GetCoreInfo();

            Assert.AreEqual("ok", info.Result);
            Assert.IsNotNull(info.Data);
            Assert.IsNotNull(info.Data.Version);
        }
    }
}
