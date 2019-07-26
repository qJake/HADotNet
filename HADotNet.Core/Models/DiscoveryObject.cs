using Newtonsoft.Json;

namespace HADotNet.Core.Models
{
    /// <summary>
    /// Represents a discovery info object, used to convey basic information about the HA instance.
    /// </summary>
    public class DiscoveryObject
    {
        /// <summary>
        /// Gets or sets the Base URL for the instance (e.g. http://192.168.0.2:8123).
        /// </summary>
        [JsonProperty("base_url")]
        public string BaseUrl { get; set; }

        /// <summary>
        /// Gets or sets the location name for this instance (e.g. "Home").
        /// </summary>
        [JsonProperty("location_name")]
        public string LocationName { get; set; }

        /// <summary>
        /// Gets or sets whether or not a password is required to use the API. (should most always be "true").
        /// </summary>
        [JsonProperty("requires_api_password")]
        public bool RequiresApiPassword { get; set; }

        /// <summary>
        /// Gets or sets the current version of Home Assistant (e.g. 0.96.1).
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets a string representation of this object.
        /// </summary>
        public override string ToString()
        {
            return $"Discovery: {LocationName} ({BaseUrl})";
        }
    }
}
