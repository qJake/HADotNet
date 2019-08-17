using HADotNet.Core;
using HADotNet.Core.Clients;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Tests
{
    public class HistoryTests
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
        public async Task ShouldRetrieveAllHistory()
        {
            var client = ClientFactory.GetClient<HistoryClient>();

            var allHistory = await client.GetHistory();

            Assert.IsNotNull(allHistory);
            Assert.IsNotEmpty(allHistory[0].EntityId);
            Assert.AreNotEqual(0, allHistory.Count);
            Assert.AreNotEqual(0, allHistory[0].Count);
        }

        [Test]
        public async Task ShouldRetrieveHistoryByEntityId()
        {
            var client = ClientFactory.GetClient<HistoryClient>();

            var history = await client.GetHistory("light.jakes_office");

            Assert.IsNotNull(history);
            Assert.IsNotEmpty(history.EntityId);
            Assert.AreNotEqual(0, history.Count);
        }

        [Test]
        public async Task ShouldRetrieveHistoryByStartDate()
        {
            var client = ClientFactory.GetClient<HistoryClient>();

            var allHistory = await client.GetHistory(new DateTimeOffset(2019, 7, 20, 0, 0, 0, TimeSpan.Zero));

            Assert.IsNotNull(allHistory);
            Assert.IsNotEmpty(allHistory[0].EntityId);
            Assert.AreNotEqual(0, allHistory.Count);
            Assert.AreNotEqual(0, allHistory[0].Count);
        }

        [Test]
        public async Task ShouldRetrieveHistoryByStartAndEndDate()
        {
            var client = ClientFactory.GetClient<HistoryClient>();

            var allHistory = await client.GetHistory(new DateTimeOffset(2019, 7, 20, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2019, 7, 20, 15, 0, 0, TimeSpan.Zero));

            Assert.IsNotNull(allHistory);
            Assert.IsNotEmpty(allHistory[0].EntityId);
            Assert.AreNotEqual(0, allHistory.Count);
            Assert.AreNotEqual(0, allHistory[0].Count);
        }

        [Test]
        public async Task ShouldRetrieveHistoryByStartDateAndDuration()
        {
            var client = ClientFactory.GetClient<HistoryClient>();

            var allHistory = await client.GetHistory(new DateTimeOffset(2019, 7, 20, 0, 0, 0, TimeSpan.Zero), TimeSpan.FromHours(18));

            Assert.IsNotNull(allHistory);
            Assert.IsNotEmpty(allHistory[0].EntityId);
            Assert.AreNotEqual(0, allHistory.Count);
            Assert.AreNotEqual(0, allHistory[0].Count);
        }

        [Test]
        public async Task ShouldRetrieveHistoryByStartAndEndDateAndEntityId()
        {
            var client = ClientFactory.GetClient<HistoryClient>();

            var history = await client.GetHistory("group.family_room_lights", new DateTimeOffset(2019, 7, 20, 0, 0, 0, TimeSpan.Zero), new DateTimeOffset(2019, 7, 25, 0, 0, 0, TimeSpan.Zero));

            Assert.IsNotNull(history);
            Assert.IsNotEmpty(history.EntityId);
            Assert.AreNotEqual(0, history.Count);
        }
    }
}