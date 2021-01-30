using System.Collections.Generic;
using Newtonsoft.Json;

namespace HADotNet.Core.Models
{
    /// <summary>
    /// Represents Supervisor info object.
    /// </summary>
    public class SupervisorInfoObject
    {
        /// <summary>
        /// Gets or sets the addons.
        /// </summary>
        [JsonProperty("addons")]
        public IList<AddonObject> Addons { get; set; }

        /// <summary>
        /// Gets or sets the addons repositories.
        /// </summary>
        [JsonProperty("addons_repositories")]
        public IList<string> AddonsRepositories { get; set; }

        /// <summary>
        /// Gets or sets the processor architecture.
        /// </summary>
        [JsonProperty("arch")]
        public string Arch { get; set; }

        /// <summary>
        /// Gets or sets the processor channel.
        /// </summary>
        [JsonProperty("channel")]
        public string Channel { get; set; }

        /// <summary>
        /// <code>True</code> if debug, otherwise <code>False</code>.
        /// </summary>
        [JsonProperty("debug")]
        public bool Debug { get; set; }

        /// <summary>
        /// <code>True</code> if debug block, otherwise <code>False</code>.
        /// </summary>
        [JsonProperty("debug_block")]
        public bool DebugBlock { get; set; }

        /// <summary>
        /// <code>True</code> if diagnostics is available, otherwise <code>False</code>.
        /// </summary>
        [JsonProperty("diagnostics")]
        public bool Diagnostics { get; set; }

        /// <summary>
        /// <code>True</code> if healthy, otherwise <code>False</code>.
        /// </summary>
        [JsonProperty("healthy")]
        public bool Healthy { get; set; }

        /// <summary>
        /// Gets or sets the IP address.
        /// </summary>
        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }

        /// <summary>
        /// Gets or sets the logging.
        /// </summary>
        [JsonProperty("logging")]
        public string Logging { get; set; }

        /// <summary>
        /// <code>True</code> if supported, otherwise <code>False</code>.
        /// </summary>
        [JsonProperty("supported")]
        public bool Supported { get; set; }

        /// <summary>
        /// Gets or sets the timezone.
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        /// <summary>
        /// <code>True</code> if update is available, otherwise <code>False</code>.
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

        /// <summary>
        /// Gets or sets the wait boot timeout.
        /// </summary>
        [JsonProperty("wait_boot")]
        public int WaitBoot { get; set; }
    }
}
