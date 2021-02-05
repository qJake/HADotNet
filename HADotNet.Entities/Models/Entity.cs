using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HADotNet.Core;
using HADotNet.Core.Constants;
using HADotNet.Core.Models;
using HADotNet.Core.Clients;
using HADotNet.Entities.Extensions;

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
        /// Attributes
        /// </summary>
        public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// Gets or sets the UTC date and time that this state was last changed.
        /// </summary>
        public DateTimeOffset LastChanged { get; set; }

        /// <summary>
        /// Gets or sets the UTC date and time that this state was last updated.
        /// </summary>
        public DateTimeOffset LastUpdated { get; set; }

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

        /// <summary>
        /// Attempts to get the value of the specified attribute by <paramref name="name" />, and cast the value to type <typeparamref name="T" />.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when the specified type <typeparamref name="T" /> cannot be cast to the attribute's current value.</exception>
        /// <typeparam name="T">The desired type to cast the attribute value to.</typeparam>
        /// <param name="name">The name of the attribute to retrieve the value for.</param>
        /// <returns>The attribute's current value, cast to type <typeparamref name="T" />.</returns>
        public T GetAttributeValue<T>(string name) => !Attributes.ContainsKey(name) ? default : (T)Attributes[name];

        /// <summary>
        /// Attempts to get the value of the specified attribute by <paramref name="name" />, and cast the value to type <typeparamref name="T" />.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when the specified type <typeparamref name="T" /> cannot be cast to the attribute's current value.</exception>
        /// <typeparam name="T">The desired type to cast the attribute value to.</typeparam>
        /// <param name="name">The name of the attribute to retrieve the value for.</param>
        /// <returns>The attribute's current value, cast to type <typeparamref name="T" />.</returns>
        public T[] GetAttributeArray<T>(string name) => Attributes.GetAttributeArray<T>(name);

        /// <summary>
        /// Gets a string representation of this entity's state.
        /// </summary>
        public override string ToString() => $"{EntityId}: {State}";
    }
}
