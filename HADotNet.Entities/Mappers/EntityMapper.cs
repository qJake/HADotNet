using HADotNet.Core.Models;
using HADotNet.Entities.Helpers;
using HADotNet.Entities.Models;

namespace HADotNet.Entities.Mappers
{
    internal static class EntityMapper
    {
        /// <summary>
        /// Maps a <see cref="StateObject"/> to a new instance of <see cref="Entity"/>
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="stateObject">The state object to apply</param>
        /// <returns></returns>
        public static TEntity MapToEntity<TEntity>(StateObject stateObject) where TEntity : Entity, new()
        {
            if (stateObject is null)
                throw new System.ArgumentNullException(nameof(stateObject));

            var entity = new TEntity();
            MapToEntity(entity, stateObject);
            return entity;
        }

        /// <summary>
        /// Maps a <see cref="StateObject"/> to an instance of <see cref="Entity"/>
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity">The entity to update</param>
        /// <param name="stateObject">The state object to apply</param>
        /// <returns></returns>
        public static TEntity MapToEntity<TEntity>(TEntity entity, StateObject stateObject) where TEntity : Entity
        {
            if (entity is null)
                throw new System.ArgumentNullException(nameof(entity));

            if (stateObject is null)
                throw new System.ArgumentNullException(nameof(stateObject));

            entity.State = stateObject.State;
            entity.EntityId = stateObject.EntityId.Split('.')[1];
            entity.EntityName = stateObject.GetFriendlyName();
            entity.LastChanged = stateObject.LastChanged;
            entity.LastUpdated = stateObject.LastUpdated;
            entity.Attributes = stateObject.Attributes;

            return entity;
        }
    }
}
