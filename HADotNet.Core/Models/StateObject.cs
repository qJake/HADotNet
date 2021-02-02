using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using HADotNet.Core.Constants;

namespace HADotNet.Core.Models
{
    /// <summary>
    /// Represents a single entity's state.
    /// </summary>
    public class StateObject
    {
        /// <summary>
        /// Gets or sets the Entity ID that this state represents.
        /// </summary>
        [JsonProperty(AttributeConstants.EntityId)]
        public string EntityId { get; set; }

        /// <summary>
        /// Gets or sets the string representation of the state that this entity is currently in.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the entity's current attributes and values.
        /// </summary>
        public Dictionary<string, object> Attributes { get; set; }
        
        /// <summary>
        /// Gets or sets the context for this entity's state.
        /// </summary>
        public ContextObject Context { get; set; }

        /// <summary>
        /// Gets or sets the UTC date and time that this state was last changed.
        /// </summary>
        [JsonProperty(AttributeConstants.LastChanged)]
        public DateTimeOffset LastChanged { get; set; }

        /// <summary>
        /// Gets or sets the UTC date and time that this state was last updated.
        /// </summary>
        [JsonProperty(AttributeConstants.LastUpdated)]
        public DateTimeOffset LastUpdated { get; set; }

        /// <summary>
        /// Attempts to get the value of the specified attribute by <paramref name="name" />, and cast the value to type <typeparamref name="T" />.
        /// </summary>
        /// <exception cref="InvalidCastException">Thrown when the specified type <typeparamref name="T" /> cannot be cast to the attribute's current value.</exception>
        /// <typeparam name="T">The desired type to cast the attribute value to.</typeparam>
        /// <param name="name">The name of the attribute to retrieve the value for.</param>
        /// <returns>The attribute's current value, cast to type <typeparamref name="T" />.</returns>
        public T GetAttributeValue<T>(string name) => !Attributes.ContainsKey(name) ? default : (T)Attributes[name];

        /// <summary>
        /// Gets a string representation of this entity's state.
        /// </summary>
        public override string ToString() => $"{EntityId}: {State}";
    }
}
