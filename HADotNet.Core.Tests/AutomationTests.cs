using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HADotNet.Core.Clients;
using HADotNet.Core.Models;
using HADotNet.Core.Tests.Infrastructure;
using NUnit.Framework;

namespace HADotNet.Core.Tests
{
    /// <summary>
    /// The tests for <see cref="AutomationClient"/>.
    /// </summary>
    public class AutomationTests
    {
        private AutomationClient Client;
        private string AutomationId { get; set; }

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            // arrange
            AutomationId = Guid.NewGuid().ToString();
            var instance = new Uri(Environment.GetEnvironmentVariable("HADotNet:Tests:Instance"));
            var apiKey = Environment.GetEnvironmentVariable("HADotNet:Tests:ApiKey");

            ClientFactory.Initialize(instance, apiKey, DefaultHttpClientFactory.GetInstance());

            Client = ClientFactory.GetClient<AutomationClient>();

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
            var result = await Client.Create(automation);
            
            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ok", result.Result);
        }

        [OneTimeTearDown]
        public async Task OneTimeTearDown()
        {
            // act
            var result = await Client.Delete(AutomationId);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ok", result.Result);
        }

        [Test]
        public async Task ShouldRetrieveAutomationById()
        {
            // act
            var automation = await Client.Get(AutomationId);

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

            // act
            var result = await Client.Update(automation);

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ok", result.Result);
        }
    }
}
