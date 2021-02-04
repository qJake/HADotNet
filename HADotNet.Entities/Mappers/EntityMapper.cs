using HADotNet.Core.Models;
using HADotNet.Entities.Helpers;
using HADotNet.Entities.Models;

namespace HADotNet.Entities.Mappers
{
    public class EntityMapper
    {
        /// <summary>
        /// Maps a <see cref="StateObject"/> to an instance of <see cref="Entity"/>
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="stateObject"></param>
        /// <returns></returns>
        public static TEntity MapToEntity<TEntity>(StateObject stateObject) where TEntity : Entity, new()
        {
            var entity = new TEntity
            {
                State = stateObject.State,
                EntityId = stateObject.EntityId.Split('.')[1],
                EntityName = stateObject.GetFriendlyName(),
                Attributes = stateObject.Attributes
            };

            return entity;
        }
    }
}
