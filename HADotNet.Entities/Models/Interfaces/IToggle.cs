using System.Threading.Tasks;
using System.Collections.Generic;
using HADotNet.Core.Models;

namespace HADotNet.Entities.Models.Interfaces
{
    /// <summary>
    /// Marks a class as able to Toggle
    /// </summary>
    public interface IToggle
    {
        /// <summary>
        /// Toggle the entity
        /// </summary>
        /// <returns></returns>
        Task<List<StateObject>> Toggle();
    }
}
