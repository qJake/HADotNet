using System;
using System.Threading.Tasks;
using HADotNet.Core.Clients;
using HADotNet.Core.Tests.Infrastructure;
using NUnit.Framework;

namespace HADotNet.Core.Tests
{
    public class CalendarTests
    {
        private CalendarClient Client { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            var instance = new Uri(Environment.GetEnvironmentVariable("HADotNet:Tests:Instance"));
            var apiKey = Environment.GetEnvironmentVariable("HADotNet:Tests:ApiKey");

            ClientFactory.Initialize(instance, apiKey, DefaultHttpClientFactory.GetInstance());

            Client = ClientFactory.GetClient<CalendarClient>();
        }

        [Test]
        public async Task ShouldRetrieveCalendarItemsForDays()
        {
            var events = await Client.GetEvents("mycalendar");

            Assert.IsNotNull(events);
            Assert.AreNotEqual(0, events.Count);
        }

        [Test]
        public async Task ShouldRetrieveCalendarItemsForTimeRange()
        {
            var events = await Client.GetEvents("mycalendar", DateTimeOffset.Now.Subtract(TimeSpan.FromDays(30)), DateTimeOffset.Now.AddDays(90));

            Assert.IsNotNull(events);
            Assert.AreNotEqual(0, events.Count);
        }
    }
}