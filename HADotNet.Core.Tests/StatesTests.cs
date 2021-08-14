using HADotNet.Core.Clients;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HADotNet.Core.Tests
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

            var state = await client.GetState("climate.thermostat");

            Assert.IsNotNull(state);
            Assert.AreEqual("heat_cool", state.GetAttributeValue<string[]>("hvac_modes")[0]);
        }

        [Test]
        public async Task ShouldSetState()
        {
            var client = ClientFactory.GetClient<StatesClient>();

            var state = await client.SetState("sensor.hadotnet_test_entity", "testing");

            Assert.IsNotNull(state);
            Assert.AreEqual("testing", state.State);
        }

        [Test]
        public async Task ShouldSetStateWithAttributes()
        {
            var client = ClientFactory.GetClient<StatesClient>();

            var state = await client.SetState("sensor.hadotnet_test_entity", "testing",
                new Dictionary<string, object>
                {
                    ["source"] = "HADotNet",
                    ["friendly_name"] = "HADotNet Unit Test Value",
                    ["icon"] = "mdi:language-csharp"
                });

            Assert.IsNotNull(state);
            Assert.AreEqual("testing", state.State);
        }
    }
}