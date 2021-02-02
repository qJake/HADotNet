using System.Collections.Generic;
using System.Threading.Tasks;
using HADotNet.Core.Constants;
using HADotNet.Core.Models;

namespace HADotNet.Entities.Models
{
    /// <summary>
    /// Represents a switch entity
    /// </summary>
    public class Switch : Entity
    {
        public Switch() : base(DomainConstants.Switch)
        {
        }

        /// <summary>
        /// Turn on the switch
        /// </summary>
        /// <returns></returns>
        public Task<List<StateObject>> TurnOn()
        {
            return CallService(ServiceConstants.TurnOn);
        }

        /// <summary>
        /// Turn off the switch
        /// </summary>
        /// <returns></returns>
        public Task<List<StateObject>> TurnOff()
        {
            return CallService(ServiceConstants.TurnOff);
        }

        /// <summary>
        /// Toggle the switch
        /// </summary>
        /// <returns></returns>
        public Task<List<StateObject>> Toggle()
        {
            return CallService(ServiceConstants.Toggle);
        }
    }
}
