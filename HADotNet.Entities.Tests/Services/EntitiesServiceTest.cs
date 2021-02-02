using System.Threading.Tasks;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using HADotNet.Core.Clients;
using HADotNet.Entities.Services;
using HADotNet.Entities.Models;

namespace HADotNet.Entities.Tests.Services
{
    public class EntitiesServiceTest
    {
        private Mock<EntityClient> _entityClientMock;
        private Mock<StatesClient> _statesClientMock;

        private EntitiesService _entitiesService;

        [SetUp]
        public void Setup()
        {
            _entityClientMock = new Mock<EntityClient>();
            _statesClientMock = new Mock<StatesClient>();

            _entitiesService = new EntitiesService(_entityClientMock.Object, _statesClientMock.Object);
        }

        [Test]
        public async Task GetEntities_ShouldCallEntityClientWithDomain()
        {
            _entityClientMock.Setup(m => m.GetEntities("light")).Returns(Task.FromResult<IEnumerable<string>>(new List<string>()));

            var lights = await _entitiesService.GetEntities<Light>();

            _entityClientMock.Verify(m => m.GetEntities("light"), Times.Once);
        }
    }
}
