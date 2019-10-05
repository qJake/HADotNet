using HADotNet.Core;
using HADotNet.Core.Clients;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Tests
{
    public class CalendarTests
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
        public async Task ShouldRetrieveCalendarItemsForDays()
        {
            var client = ClientFactory.GetClient<CalendarClient>();

            var events = await client.GetEvents("mycalendar");

            Assert.IsNotNull(events);
            Assert.AreNotEqual(0, events.Count);
        }

        [Test]
        public async Task ShouldRetrieveCalendarItemsForTimeRange()
        {
            var client = ClientFactory.GetClient<CalendarClient>();

            var events = await client.GetEvents("mycalendar", DateTimeOffset.Now.Subtract(TimeSpan.FromDays(30)), DateTimeOffset.Now.AddDays(90));

            Assert.IsNotNull(events);
            Assert.AreNotEqual(0, events.Count);
        }
    }
}