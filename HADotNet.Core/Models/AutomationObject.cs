using System.Collections.Generic;
using Newtonsoft.Json;

namespace HADotNet.Core.Models
{
    /// <summary>
    /// Represents automation object.
    /// </summary>
    public class AutomationObject
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the alias.
        /// </summary>
        [JsonProperty("alias")]
        public string Alias { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the actions.
        /// </summary>
        [JsonProperty("action")]
        public List<Dictionary<string, object>> Actions { get; set; }

        /// <summary>
        /// Gets or sets the conditions.
        /// </summary>
        [JsonProperty("condition")]
        public List<Dictionary<string, object>> Conditions { get; set; }

        /// <summary>
        /// Gets or sets the triggers.
        /// </summary>
        [JsonProperty("trigger")]
        public List<Dictionary<string, object>> Triggers { get; set; } = new List<Dictionary<string, object>>();
    }
}
