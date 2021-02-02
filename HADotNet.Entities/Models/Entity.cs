using System.Collections.Generic;
using System.Threading.Tasks;
using HADotNet.Core;
using HADotNet.Core.Constants;
using HADotNet.Core.Clients;
using HADotNet.Core.Models;

namespace HADotNet.Entities.Models
{
    /// <summary>
    /// Represents a single entity
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Gets or sets the Entity ID
        /// </summary>
        public string EntityId { get; set; }

        /// <summary>
        /// Gets or sets the Entity name
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// Gets or sets the Entity's domain
        /// </summary>
        public string Domain { get; private set; }

        /// <summary>
        /// Gets the current state
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// The service client
        /// </summary>
        protected ServiceClient ServiceClient { get; } = ClientFactory.GetClient<ServiceClient>();

        /// <summary>
        /// Creates an entity
        /// </summary>
        /// <param name="domain"></param>
        protected Entity(string domain)
        {
            Domain = domain;
        }

        /// <summary>
        /// Gets the full entity id in the form of [domain].[entityId]
        /// </summary>
        /// <returns></returns>
        public string GetFullEntityId()
        {
            return $"{Domain}.{EntityId}";
        }

        /// <summary>
        /// Make a service call for the current entity
        /// </summary>
        /// <param name="service"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        protected Task<List<StateObject>> CallService(string service, IDictionary<string, object> fields = null)
        {
            if (fields == null)
            {
                fields = new Dictionary<string, object>();
            }
            if (!fields.ContainsKey(AttributeConstants.EntityId))
            {
                fields.Add(AttributeConstants.EntityId, GetFullEntityId());
            }

            return ServiceClient.CallService(Domain, service, fields);
        }
    }
}
