using HADotNet.Core.Constants;

namespace HADotNet.Entities.Models
{
    /// <summary>
    /// Represents a binary sensor entity
    /// </summary>
    public class BinarySensor : Entity
    {
        /// <summary>
        /// Creates a binary sensor entity
        /// </summary>
        public BinarySensor() : base(DomainConstants.BinarySensor)
        {
        }
    }
}
