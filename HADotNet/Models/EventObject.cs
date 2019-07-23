using Newtonsoft.Json;

namespace HADotNet.Core.Models
{
    /// <summary>
    /// Represents an event definition in Home Assistant.
    /// </summary>
    public class EventObject
    {
        /// <summary>
        /// Gets the global event string (*).
        /// </summary>
        public static readonly string GlobalEvent = "*";

        /// <summary>
        /// Gets the event's name.
        /// </summary>
        public string Event { get; set; }

        /// <summary>
        /// Gets the listener count for this event.
        /// </summary>
        [JsonProperty("listener_count")]
        public int ListenerCount { get; set; }
    }
}
