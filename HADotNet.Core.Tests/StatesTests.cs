using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HADotNet.Core.Clients;
using HADotNet.Core.Tests.Infrastructure;
using NUnit.Framework;

namespace HADotNet.Core.Tests
{
    public class StatesTests
    {
        private StatesClient Client { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            var instance = new Uri(Environment.GetEnvironmentVariable("HADotNet:Tests:Instance"));
            var apiKey = Environment.GetEnvironmentVariable("HADotNet:Tests:ApiKey");

            ClientFactory.Initialize(instance, apiKey, DefaultHttpClientFactory.GetInstance());

            Client = ClientFactory.GetClient<StatesClient>();
        }

        [Test]
        public async Task ShouldRetrieveStateList()
        {
            var states = await Client.GetStates();

            Assert.IsNotNull(states);
            Assert.AreNotEqual(0, states.Count);
        }

        [Test]
        public async Task ShouldRetrieveState()
        {
            var state = await Client.GetState("sun.sun");

            Assert.IsNotNull(state);
            Assert.IsNotEmpty(state.State);
        }

        [Test]
        public async Task ShouldRetrieveStateAttributeValue()
        {
            var state = await Client.GetState("sun.sun");

            Assert.IsNotNull(state);
            Assert.AreEqual("Sun", state.GetAttributeValue<string>("friendly_name"));
        }

        [Test]
        public async Task ShouldSetState()
        {
            var state = await Client.SetState("sensor.hadotnet_test_entity", "testing");

            Assert.IsNotNull(state);
            Assert.AreEqual("testing", state.State);
        }

        [Test]
        public async Task ShouldSetStateWithAttributes()
        {
            var state = await Client.SetState("sensor.hadotnet_test_entity", "testing",
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