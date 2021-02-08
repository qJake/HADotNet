using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using HADotNet.Core;
using HADotNet.Core.Constants;
using HADotNet.Core.Models;
using HADotNet.Core.Clients;
using HADotNet.Entities.Extensions;
using HADotNet.Entities.Mappers;
using HADotNet.Entities.Models.Interfaces;

namespace HADotNet.Entities.Models
{
    /// <summary>
    /// Represents a single entity
    /// </summary>
    public abstract class Entity : IUpdate
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
        /// The states client
        /// </summary>
        protected StatesClient StatesClient { get; } = ClientFactory.GetClient<StatesClient>();

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
        /// Update the properties of the entity
        /// </summary>
        /// <returns></returns>
        public async Task<StateObject> Update()
        {
            var newState = await StatesClient.GetState(GetFullEntityId());
            Update(newState);
            return newState;
        }

        /// <summary>
        /// Update the properties of the entity with the given <see cref="StateObject"/>
        /// </summary>
        /// <param name="newState"></param>
        public void Update(StateObject newState)
        {
            if (newState != null)
            {
                EntityMapper.MapToEntity(this, newState);
            }
        }

        /// <summary>
        /// Make a service call for the current entity
        /// </summary>
        /// <param name="service">The service to call</param>
        /// <param name="fields">Extra parameters to send with the service</param>
        /// <returns></returns>
        protected async Task<List<StateObject>> CallService(string service, IDictionary<string, object> fields = null)
        {
            var fullEntityId = GetFullEntityId();
            if (fields == null)
            {
                fields = new Dictionary<string, object>();
            }
            if (!fields.ContainsKey(AttributeConstants.EntityId))
            {
                fields.Add(AttributeConstants.EntityId, fullEntityId);
            }

            var stateObjects = await ServiceClient.CallService(Domain, service, fields);

            // TODO: What to do with other updated entities?
            var updatedStateObject = stateObjects.FirstOrDefault(so => so.EntityId == fullEntityId);
            Update(updatedStateObject);

            return stateObjects;
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
        public override string ToString() => $"{GetFullEntityId()}: {State}";
    }
}
