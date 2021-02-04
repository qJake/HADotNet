using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HADotNet.Core;
using HADotNet.Core.Clients;
using HADotNet.Entities.Helpers;
using HADotNet.Entities.Mappers;
using HADotNet.Entities.Models;

namespace HADotNet.Entities.Services
{
    /// <summary>
    /// Class to retrieve specific type of entities
    /// </summary>
    public class EntitiesService
    {
        private readonly EntityClient _entityClient;
        private readonly StatesClient _statesClient;

        /// <summary>
        /// Creates an instance of the <see cref="EntitiesService"/>
        /// </summary>
        public EntitiesService() : this(ClientFactory.GetClient<EntityClient>(), ClientFactory.GetClient<StatesClient>())
        {
        }

        /// <summary>
        /// Creates an instance of the <see cref="EntitiesService"/>
        /// </summary>
        /// <param name="entityClient"></param>
        /// <param name="statesClient"></param>
        public EntitiesService(EntityClient entityClient, StatesClient statesClient)
        {
            _entityClient = entityClient;
            _statesClient = statesClient;
        }

        /// <summary>
        /// Get all entities of a specific domain
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetEntities<TEntity>() where TEntity : Entity, new()
        {
            var domain = EntityHelper.GetDomainFromEntityType<TEntity>();
            var entityIds = await _entityClient.GetEntities(domain);

            var entityTasks = entityIds.Select(entityId => GetEntity<TEntity>(entityId)).ToArray();

            return await Task.WhenAll(entityTasks);
        }

        /// <summary>
        /// Get an entity of a specific domain
        /// </summary>
        /// <typeparam name="TEntity">The type of entity to get</typeparam>
        /// <param name="entityId">The entityId to get from the given TEntity domain, either in [domain].[entity_id] or just [entity_id]</param>
        /// <returns></returns>
        public async Task<TEntity> GetEntity<TEntity>(string entityId) where TEntity : Entity, new()
        {
            if (!entityId.Contains("."))
            {
                entityId = $"{EntityHelper.GetDomainFromEntityType<TEntity>()}.{entityId}";
            }

            var entityState = await _statesClient.GetState(entityId);

            var entity = EntityMapper.MapToEntity<TEntity>(entityState);

            return entity;
        }
    }
}
