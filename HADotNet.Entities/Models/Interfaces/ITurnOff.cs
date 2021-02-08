using System.Threading.Tasks;
using System.Collections.Generic;
using HADotNet.Core.Models;

namespace HADotNet.Entities.Models.Interfaces
{
    /// <summary>
    /// Marks a class as able to Turn Off
    /// </summary>
    public interface ITurnOff
    {
        /// <summary>
        /// Turn Off the entity
        /// </summary>
        /// <returns></returns>
        Task<List<StateObject>> TurnOff();
    }
}
