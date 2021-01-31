using Newtonsoft.Json;

namespace HADotNet.Core.Models
{
    /// <summary>
    /// Represents Add-on object.
    /// </summary>
    public class AddonObject
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// <c>True</c> if icon is available, otherwise <c>False</c>.
        /// </summary>
        [JsonProperty("icon")]
        public bool Icon { get; set; }

        /// <summary>
        /// <c>True</c> if logo is available, otherwise <c>False</c>.
        /// </summary>
        [JsonProperty("logo")]
        public bool Logo { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        [JsonProperty("repository")]
        public string Repository { get; set; }

        /// <summary>
        /// Gets or sets the slug.
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// <c>True</c> if update is available, otherwise <c>False</c>.
        /// </summary>
        [JsonProperty("update_available")]
        public bool UpdateAvailable { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the latest version.
        /// </summary>
        [JsonProperty("version_latest")]
        public string VersionLatest { get; set; }
    }
}
