using HADotNet.Core.Clients;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HADotNet.Core.Models.Entities
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
        public string Domain { get; set; }

        protected ServiceClient ServiceClient { get; private set; }

        protected Entity(string domain) : this(domain, null) { }

        protected Entity(string domain, string entityId) : this(domain, entityId, null) { }

        protected Entity(string domain, string entityId, string entityName)
        {
            EntityId = entityId;
            EntityName = entityName;
            Domain = domain;

            ServiceClient = ClientFactory.GetClient<ServiceClient>();
        }

        protected Task<List<StateObject>> CallService(string service)
        {
            return CallService(service, new { entity_id = EntityId });
        }

        protected Task<List<StateObject>> CallService(string service, object fields = null)
        {
            return ServiceClient.CallService(Domain, service, fields);
        }
    }
}
