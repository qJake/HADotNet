using System.Threading.Tasks;
using System.Collections.Generic;
using HADotNet.Core.Models;

namespace HADotNet.Entities.Models.Interfaces
{
    /// <summary>
    /// Marks a class as able to Turn On
    /// </summary>
    public interface ITurnOn
    {
        /// <summary>
        /// Turn On the entity
        /// </summary>
        /// <returns></returns>
        Task<List<StateObject>> TurnOn();
    }
}
