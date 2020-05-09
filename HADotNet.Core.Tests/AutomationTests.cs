using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HADotNet.Core;
using HADotNet.Core.Clients;
using HADotNet.Core.Models;
using NUnit.Framework;

namespace Tests
{
    /// <summary>
    /// The tests for <see cref="AutomationClient"/>.
    /// </summary>
    public class AutomationTests
    {
        private Uri Instance { get; set; }
        private string ApiKey { get; set; }
        private string AutomationId { get; set; }

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            // arrange
            AutomationId = Guid.NewGuid().ToString();
            Instance = new Uri(Environment.GetEnvironmentVariable("HADotNet:Tests:Instance"));
            ApiKey = Environment.GetEnvironmentVariable("HADotNet:Tests:ApiKey");

            ClientFactory.Initialize(Instance, ApiKey);

            var client = ClientFactory.GetClient<AutomationClient>();

            var automation = new AutomationObject
            {
                Id = AutomationId,
                Alias = $"test_automation_{AutomationId}",
                Description = $"This is a test automation {DateTime.Now.ToLongDateString()}",
                Actions = new List<Dictionary<string, object>>() 
                { 
                    new Dictionary<string, object>()
                    {
                        { "entity_id",  "switch.switch" },
                        { "service", "switch.turn_on" }
                    }
                }
            };

            // act
            var result = await client.Create(automation);
            
            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ok", result.Result);
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            // arrange
            var client = ClientFactory.GetClient<AutomationClient>();

            // act
            var result = await client.Delete(AutomationId);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ok", result.Result);
        }

        [Test]
        public async Task ShouldRetrieveAutomationById()
        {
            // arrange
            var client = ClientFactory.GetClient<AutomationClient>();

            // act
            var automation = await client.Get(AutomationId);

            // assert
            Assert.IsNotNull(automation);
        }

        [Test]
        public async Task ShouldUpdateAutomation()
        {
            // arrange
            var automation = new AutomationObject
            {
                Id = AutomationId,
                Alias = $"test_automation_{AutomationId}",
                Description = $"This is an updated test automation {DateTime.Now.ToLongDateString()}",
                Actions = new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        { "entity_id",  "switch.switch" },
                        { "service", "switch.turn_off" }
                    }
                }
            };

            var client = ClientFactory.GetClient<AutomationClient>();

            // act
            var result = await client.Update(automation);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ok", result.Result);
        }
    }
}
