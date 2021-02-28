using System;
using System.Threading.Tasks;
using HADotNet.Core.Clients;
using HADotNet.Core.Tests.Infrastructure;
using NUnit.Framework;

namespace HADotNet.Core.Tests
{
    public class HistoryTests
    {
        private HistoryClient Client { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            var instance = new Uri(Environment.GetEnvironmentVariable("HADotNet:Tests:Instance"));
            var apiKey = Environment.GetEnvironmentVariable("HADotNet:Tests:ApiKey");

            ClientFactory.Initialize(instance, apiKey, DefaultHttpClientFactory.GetInstance());

            Client = ClientFactory.GetClient<HistoryClient>();
        }

        [Test]
        public async Task ShouldRetrieveAllHistory()
        {
            var allHistory = await Client.GetHistory();

            Assert.IsNotNull(allHistory);
            Assert.IsNotEmpty(allHistory[0].EntityId);
            Assert.AreNotEqual(0, allHistory.Count);
            Assert.AreNotEqual(0, allHistory[0].Count);
        }

        [Test]
        public async Task ShouldRetrieveHistoryByEntityId()
        {
            var history = await Client.GetHistory("light.jakes_office");

            Assert.IsNotNull(history);
            Assert.IsNotEmpty(history.EntityId);
            Assert.AreNotEqual(0, history.Count);
        }

        [Test]
        public async Task ShouldRetrieveHistoryByStartDate()
        {
            var allHistory = await Client.GetHistory(DateTimeOffset.Now.Subtract(TimeSpan.FromDays(2)));

            Assert.IsNotNull(allHistory);
            Assert.IsNotEmpty(allHistory[0].EntityId);
            Assert.AreNotEqual(0, allHistory.Count);
            Assert.AreNotEqual(0, allHistory[0].Count);
        }

        [Test]
        public async Task ShouldRetrieveHistoryByStartAndEndDate()
        {
            var allHistory = await Client.GetHistory(DateTimeOffset.Now.Subtract(TimeSpan.FromDays(2)), DateTimeOffset.Now.Subtract(new TimeSpan(1, 12, 0, 0)));

            Assert.IsNotNull(allHistory);
            Assert.IsNotEmpty(allHistory[0].EntityId);
            Assert.AreNotEqual(0, allHistory.Count);
            Assert.AreNotEqual(0, allHistory[0].Count);
        }

        [Test]
        public async Task ShouldRetrieveHistoryByStartDateAndDuration()
        {
            var allHistory = await Client.GetHistory(DateTimeOffset.Now.Subtract(TimeSpan.FromDays(2)), TimeSpan.FromHours(18));

            Assert.IsNotNull(allHistory);
            Assert.IsNotEmpty(allHistory[0].EntityId);
            Assert.AreNotEqual(0, allHistory.Count);
            Assert.AreNotEqual(0, allHistory[0].Count);
        }

        [Test]
        public async Task ShouldRetrieveHistoryByStartAndEndDateAndEntityId()
        {
            var history = await Client.GetHistory("group.family_room_lights", DateTimeOffset.Now.Subtract(TimeSpan.FromDays(2)), DateTimeOffset.Now.Subtract(new TimeSpan(1, 12, 0, 0)));

            Assert.IsNotNull(history);
            Assert.IsNotEmpty(history.EntityId);
            Assert.AreNotEqual(0, history.Count);
        }
    }
}