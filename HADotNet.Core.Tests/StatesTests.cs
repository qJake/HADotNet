using HADotNet.Core;
using HADotNet.Core.Clients;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Tests
{
    public class StatesTests
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
        public async Task ShouldRetrieveStateList()
        {
            var client = ClientFactory.GetClient<StatesClient>();

            var states = await client.GetStates();

            Assert.IsNotNull(states);
            Assert.AreNotEqual(0, states.Count);
        }

        [Test]
        public async Task ShouldRetrieveState()
        {
            var client = ClientFactory.GetClient<StatesClient>();

            var state = await client.GetState("sun.sun");

            Assert.IsNotNull(state);
            Assert.IsNotEmpty(state.State);
        }

        [Test]
        public async Task ShouldRetrieveStateAttributeValue()
        {
            var client = ClientFactory.GetClient<StatesClient>();

            var state = await client.GetState("sun.sun");

            Assert.IsNotNull(state);
            Assert.AreEqual("Sun", state.GetAttributeValue<string>("friendly_name"));
        }
    }
}