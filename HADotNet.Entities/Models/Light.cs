using System.Collections.Generic;
using System.Threading.Tasks;
using HADotNet.Core.Constants;
using HADotNet.Core.Models;
using HADotNet.Entities.Models.Interfaces;

namespace HADotNet.Entities.Models
{
    /// <summary>
    /// Represents a light entity
    /// </summary>
    public class Light : Entity, ITurnOn, ITurnOff, IToggle
    {
        /// <summary>
        /// Creates a light entity
        /// </summary>
        public Light() : base(DomainConstants.Light)
        {
        }

        /// <summary>
        /// List of possible effects
        /// </summary>
        public string[] EffectList => GetAttributeArray<string>(AttributeConstants.EffectList);

        /// <summary>
        /// List of children lights entity id's
        /// </summary>
        public string[] Children => GetAttributeArray<string>(AttributeConstants.EntityId);

        /// <summary>
        /// Maximum mireds
        /// </summary>
        public int MaxMireds => GetAttributeValue<int>(AttributeConstants.MaxMireds);

        /// <summary>
        /// Minimum mireds
        /// </summary>
        public int MinMireds => GetAttributeValue<int>(AttributeConstants.MinMireds);

        /// <summary>
        /// Turn on the light
        /// </summary>
        /// <returns></returns>
        public Task<List<StateObject>> TurnOn()
        {
            return CallService(ServiceConstants.TurnOn);
        }

        /// <summary>
        /// Turn off the light
        /// </summary>
        /// <returns></returns>
        public Task<List<StateObject>> TurnOff()
        {
            return CallService(ServiceConstants.TurnOff);
        }

        /// <summary>
        /// Toggle the light
        /// </summary>
        /// <returns></returns>
        public Task<List<StateObject>> Toggle()
        {
            return CallService(ServiceConstants.Toggle);
        }
    }
}
