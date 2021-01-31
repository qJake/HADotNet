using HADotNet.Core;
using HADotNet.Core.Clients;
using NUnit.Framework;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HADotNet.Core.Tests
{
    public class TemplateTests
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
        public async Task ShouldRenderSunTemplate()
        {
            var client = ClientFactory.GetClient<TemplateClient>();

            var result = await client.RenderTemplate("The sun is {{ states('sun.sun') }}");

            Assert.IsNotNull(result);
            Assert.IsTrue(Regex.IsMatch(result, "^The sun is (?:above_horizon|below_horizon)$"));
        }
    }
}