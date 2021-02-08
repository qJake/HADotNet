using HADotNet.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HADotNet.Entities
{
    public interface IEntitiesService
    {
        Task<IEnumerable<TEntity>> GetEntities<TEntity>() where TEntity : Entity, new();
        Task<TEntity> GetEntity<TEntity>(string entityId) where TEntity : Entity, new();
    }
}