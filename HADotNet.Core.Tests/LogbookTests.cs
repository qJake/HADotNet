using System;
using System.Threading.Tasks;
using HADotNet.Core.Clients;
using HADotNet.Core.Tests.Infrastructure;
using NUnit.Framework;

namespace HADotNet.Core.Tests
{
    public class LogbookTests
    {
        private LogbookClient Client { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            var instance = new Uri(Environment.GetEnvironmentVariable("HADotNet:Tests:Instance"));
            var apiKey = Environment.GetEnvironmentVariable("HADotNet:Tests:ApiKey");

            ClientFactory.Initialize(instance, apiKey, DefaultHttpClientFactory.GetInstance());

            Client = ClientFactory.GetClient<LogbookClient>();
        }

        [Test]
        public async Task ShouldRetrieveAllLogbookEntries()
        {
            var logEntries = await Client.GetLogbookEntries();

            Assert.IsNotNull(logEntries);
            Assert.IsNotEmpty(logEntries[0].EntityId);
            Assert.AreNotEqual(0, logEntries.Count);
            Assert.AreNotEqual(string.Empty, logEntries[0].EntityId);
        }

        [Test]
        public async Task ShouldRetrieveLogbookEntriesByEntityId()
        {
            var history = await Client.GetLogbookEntries("light.jakes_office");

            Assert.IsNotNull(history);
            Assert.IsNotEmpty(history.EntityId);
        }

        [Test]
        public async Task ShouldRetrieveLogbookEntriesByStartDate()
        {
            var logEntries = await Client.GetLogbookEntries(DateTimeOffset.Now.Subtract(TimeSpan.FromDays(2)));

            Assert.IsNotNull(logEntries);
            Assert.IsNotEmpty(logEntries[0].EntityId);
            Assert.AreNotEqual(0, logEntries.Count);
            Assert.AreNotEqual(string.Empty, logEntries[0].EntityId);
        }

        [Test]
        public async Task ShouldRetrieveLogbookEntriesByStartAndEndDate()
        {
            var logEntries = await Client.GetLogbookEntries(DateTimeOffset.Now.Subtract(TimeSpan.FromDays(2)), DateTimeOffset.Now.Subtract(new TimeSpan(1, 12, 0, 0)));

            Assert.IsNotNull(logEntries);
            Assert.IsNotEmpty(logEntries[0].EntityId);
            Assert.AreNotEqual(0, logEntries.Count);
            Assert.AreNotEqual(string.Empty, logEntries[0].EntityId);
        }

        [Test]
        public async Task ShouldRetrieveLogbookEntriesByStartDateAndDuration()
        {
            var logEntries = await Client.GetLogbookEntries(DateTimeOffset.Now.Subtract(TimeSpan.FromDays(2)), TimeSpan.FromHours(18));

            Assert.IsNotNull(logEntries);
            Assert.IsNotEmpty(logEntries[0].EntityId);
            Assert.AreNotEqual(0, logEntries.Count);
            Assert.AreNotEqual(string.Empty, logEntries[0].EntityId);
        }

        [Test]
        public async Task ShouldRetrieveLogbookEntriesByStartAndEndDateAndEntityId()
        {
            var history = await Client.GetLogbookEntries("group.family_room_lights", DateTimeOffset.Now.Subtract(TimeSpan.FromDays(2)), DateTimeOffset.Now.Subtract(new TimeSpan(1, 12, 0, 0)));

            Assert.IsNotNull(history);
            Assert.IsNotEmpty(history.EntityId);
        }
    }
}