using NUnit.Framework;
using HADotNet.Entities.Models;
using HADotNet.Entities.Helpers;

namespace HADotNet.Entities.Tests.Helpers
{
    public class EntityHelperTest
    {
        [Test]
        public void GetDomainFromLight_ShouldConvertToCorrectHaDomain()
        {
            var domain = EntityHelper.GetDomainFromEntityType<Light>();

            Assert.AreEqual("light", domain);
        }

        [Test]
        public void GetDomainFromSwitch_ShouldConvertToCorrectHaDomain()
        {
            var domain = EntityHelper.GetDomainFromEntityType<Switch>();

            Assert.AreEqual("switch", domain);
        }

        [Test]
        public void GetDomainFromBinarySensor_ShouldConvertToCorrectHaDomain()
        {
            var domain = EntityHelper.GetDomainFromEntityType<BinarySensor>();

            Assert.AreEqual("binary_sensor", domain);
        }
    }
}
