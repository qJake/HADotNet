using System;
using System.Threading.Tasks;
using HADotNet.Core.Clients;
using NUnit.Framework;

namespace HADotNet.Core.Tests
{
    public class CameraProxyTests
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
        public async Task ShouldRetrieveCameraData()
        {
            var client = ClientFactory.GetClient<CameraProxyClient>();

            var imageData = await client.GetCameraImage("camera.garage");

            Assert.IsNotNull(imageData);
            Assert.AreNotEqual(0, imageData.Length);
        }

        [Test]
        public async Task ShouldRetrieveCameraDataAsBase64Encoded()
        {
            var client = ClientFactory.GetClient<CameraProxyClient>();

            var imageData = await client.GetCameraImageAsBase64("camera.garage");

            Assert.IsNotNull(imageData);
            Assert.AreNotEqual(0, imageData.Length);
        }
    }
}