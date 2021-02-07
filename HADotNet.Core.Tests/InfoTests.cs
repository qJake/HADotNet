using System;
using System.Threading.Tasks;
using HADotNet.Core.Clients;
using HADotNet.Core.Tests.Infrastructure;
using NUnit.Framework;

namespace HADotNet.Core.Tests
{
    /// <summary>
    /// Tests for the Supervisor Info endpoints.
    /// </summary>
    /// <remarks>
    /// NOTE: If you want to test against a non-Supervisor instance, you'll need to set
    /// the compilation symbol TEST_ENV_HA_CORE which will test for the correct exception.
    /// </remarks>
    public class InfoTests
    {
        private InfoClient Client;

        [OneTimeSetUp]
        public void Setup()
        {
            var instance = new Uri(Environment.GetEnvironmentVariable("HADotNet:Tests:Instance"));
            var apiKey = Environment.GetEnvironmentVariable("HADotNet:Tests:ApiKey");

            ClientFactory.Initialize(instance, apiKey, DefaultHttpClientFactory.GetInstance());

            Client = ClientFactory.GetClient<InfoClient>();
        }

        [Test]
        public async Task ShouldRetrieveSupervisorInfo()
        {
#if TEST_ENV_HA_CORE
            Assert.ThrowsAsync<SupervisorNotFoundException>(async () => await client.GetSupervisorInfo());
#else
            var info = await Client.GetSupervisorInfo();

            Assert.AreEqual("ok", info.Result);
            Assert.IsNotNull(info.Data);
            Assert.IsNotNull(info.Data.Version);
#endif
        }

        [Test]
        public async Task ShouldRetrieveHostInfo()
        {
#if TEST_ENV_HA_CORE
            Assert.ThrowsAsync<SupervisorNotFoundException>(async () => await client.GetHostInfo());
#else
            var info = await Client.GetHostInfo();

            Assert.AreEqual("ok", info.Result);
            Assert.IsNotNull(info.Data);
            Assert.IsNotNull(info.Data.OperatingSystem);
#endif
        }

        [Test]
        public async Task ShouldRetrieveCoreInfo()
        {
#if TEST_ENV_HA_CORE
            Assert.ThrowsAsync<SupervisorNotFoundException>(async () => await client.GetCoreInfo());
#else
            var info = await Client.GetCoreInfo();

            Assert.AreEqual("ok", info.Result);
            Assert.IsNotNull(info.Data);
            Assert.IsNotNull(info.Data.Version);
#endif
        }
    }
}
