using System.Threading.Tasks;
using HADotNet.Core.Models;

namespace HADotNet.Entities.Models.Interfaces
{
    /// <summary>
    /// Marks a class as able to Update
    /// </summary>
    public interface IUpdate
    {
        /// <summary>
        /// Update the entity
        /// </summary>
        /// <returns></returns>
        Task<StateObject> Update();
    }
}
