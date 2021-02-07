using System;
using System.Threading.Tasks;
using HADotNet.Core.Clients;
using HADotNet.Core.Tests.Infrastructure;
using NUnit.Framework;

namespace HADotNet.Core.Tests
{
    public class ErrorLogTests
    {
        private ErrorLogClient Client { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            var instance = new Uri(Environment.GetEnvironmentVariable("HADotNet:Tests:Instance"));
            var apiKey = Environment.GetEnvironmentVariable("HADotNet:Tests:ApiKey");

            ClientFactory.Initialize(instance, apiKey, DefaultHttpClientFactory.GetInstance());

            Client = ClientFactory.GetClient<ErrorLogClient>();
        }

        [Test]
        public async Task ShouldRetrieveErrorLogList()
        {
            var log = await Client.GetErrorLogEntries();

            Assert.IsNotNull(log);
            Assert.AreNotEqual(0, log.LogEntries.Count);
            Assert.AreNotEqual(0, log.Errors.Count);
            Assert.AreNotEqual(0, log.Warnings.Count);
            Assert.AreEqual(7, log[7].Count);
        }
    }
}