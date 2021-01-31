using System;
using System.Threading.Tasks;
using HADotNet.Core.Clients;
using HADotNet.Core.Domain;
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

#if TEST_ENV_HA_CORE
            Assert.ThrowsAsync<SupervisorNotFoundException>(async () => await client.GetSupervisorInfo());
#else
            var info = await client.GetSupervisorInfo();

            Assert.AreEqual("ok", info.Result);
            Assert.IsNotNull(info.Data);
            Assert.IsNotNull(info.Data.Version);
#endif
        }

        [Test]
        public async Task ShouldRetrieveHostInfo()
        {
            var client = ClientFactory.GetClient<InfoClient>();

#if TEST_ENV_HA_CORE
            Assert.ThrowsAsync<SupervisorNotFoundException>(async () => await client.GetHostInfo());
#else
            var info = await client.GetHostInfo();

            Assert.AreEqual("ok", info.Result);
            Assert.IsNotNull(info.Data);
            Assert.IsNotNull(info.Data.OperatingSystem);
#endif
        }

        [Test]
        public async Task ShouldRetrieveCoreInfo()
        {
            var client = ClientFactory.GetClient<InfoClient>();

#if TEST_ENV_HA_CORE
            Assert.ThrowsAsync<SupervisorNotFoundException>(async () => await client.GetCoreInfo());
#else
            var info = await client.GetCoreInfo();

            Assert.AreEqual("ok", info.Result);
            Assert.IsNotNull(info.Data);
            Assert.IsNotNull(info.Data.Version);
#endif
        }
    }
}
