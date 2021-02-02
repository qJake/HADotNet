using System.Linq;
using System.Text.RegularExpressions;
using HADotNet.Core.Models;
using HADotNet.Entities.Models;

namespace HADotNet.Entities.Helpers
{
    public static class EntityHelper
    {
        /// <summary>
        /// Get the friendly name of a stateObject
        /// </summary>
        /// <param name="stateObject"></param>
        /// <returns></returns>
        public static string GetFriendlyName(this StateObject stateObject)
        {
            var friendlyName = stateObject.GetAttributeValue<string>("friendly_name");
            if (string.IsNullOrEmpty(friendlyName))
            {
                friendlyName = ToFriendlyName(stateObject.EntityId);
            }

            return friendlyName;
        }

        /// <summary>
        /// Converts an entityId to a friendly name
        /// </summary>
        /// <param name="entityId">The entity id in the form of [domain].[entity_name]</param>
        /// <returns></returns>
        public static string ToFriendlyName(string entityId)
        {
            // [domain].[entity_name] => Entity name
            // [entity_name] => Entity name
            var splittedWords = (entityId.Contains(".") ? entityId.Split('.')[1] : entityId).Split('_');
            var friendlyName = string.Join(" ", splittedWords.Select(word => word.First().ToString().ToUpper() + word.Substring(1)));
            return friendlyName;
        }

        /// <summary>
        /// Gets the HA domain from a given entity type
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public static string GetDomainFromEntityType<TEntity>() where TEntity : Entity
        {
            // TEntity => [domain_name]
            return string.Join("_", Regex.Split(typeof(TEntity).Name, @"(?<!^)(?=[A-Z])").Select(part => part.ToLower()));
        }
    }
}
