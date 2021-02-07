using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HADotNet.Core.Clients;
using HADotNet.Core.Tests.Infrastructure;
using NUnit.Framework;

namespace HADotNet.Core.Tests
{
    public class TemplateTests
    {
        private TemplateClient Client { get; set; }

        [OneTimeSetUp]
        public void Setup()
        {
            var instance = new Uri(Environment.GetEnvironmentVariable("HADotNet:Tests:Instance"));
            var apiKey = Environment.GetEnvironmentVariable("HADotNet:Tests:ApiKey");

            ClientFactory.Initialize(instance, apiKey, DefaultHttpClientFactory.GetInstance());

            Client = ClientFactory.GetClient<TemplateClient>();
        }

        [Test]
        public async Task ShouldRenderSunTemplate()
        {
            var result = await Client.RenderTemplate("The sun is {{ states('sun.sun') }}");

            Assert.IsNotNull(result);
            Assert.IsTrue(Regex.IsMatch(result, "^The sun is (?:above_horizon|below_horizon)$"));
        }
    }
}