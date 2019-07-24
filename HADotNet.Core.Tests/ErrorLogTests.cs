using HADotNet.Core;
using HADotNet.Core.Clients;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Tests
{
    public class ErrorLogTests
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
        public async Task ShouldRetrieveErrorLogList()
        {
            var client = ClientFactory.GetClient<ErrorLogClient>();

            var log = await client.GetErrorLogEntries();

            Assert.IsNotNull(log);
            Assert.AreNotEqual(0, log.LogEntries.Count);
            Assert.AreNotEqual(0, log.Errors.Count);
            Assert.AreNotEqual(0, log.Warnings.Count);
            Assert.AreEqual(7, log[7].Count);
        }
    }
}