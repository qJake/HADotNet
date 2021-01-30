using Newtonsoft.Json;

namespace HADotNet.Core.Models
{
    /// <summary>
    /// Represents Core info object.
    /// </summary>
    public class CoreInfoObject
    {
        /// <summary>
        /// Gets or sets the processor architecture.
        /// </summary>
        [JsonProperty("arch")]
        public string Arch { get; set; }

        /// <summary>
        /// Gets or sets the audio input.
        /// </summary>
        [JsonProperty("audio_input")]
        public string AudioInput { get; set; }

        /// <summary>
        /// Gets or sets the audio output.
        /// </summary>
        [JsonProperty("audio_output")]
        public string AudioOutput { get; set; }

        /// <summary>
        /// <code>True</code> if booted, otherwise <code>False</code>.
        /// </summary>
        [JsonProperty("boot")]
        public bool Boot { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        [JsonProperty("image")]
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the IP address.
        /// </summary>
        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }

        /// <summary>
        /// Gets or sets the last_version.
        /// </summary>
        [JsonProperty("last_version")]
        public string LastVersion { get; set; }

        /// <summary>
        /// Gets or sets the machine.
        /// </summary>
        [JsonProperty("machine")]
        public string Machine { get; set; }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        [JsonProperty("port")]
        public int Port { get; set; }

        /// <summary>
        /// <code>True</code> if SSL is enabled, otherwise <code>False</code>.
        /// </summary>
        [JsonProperty("ssl")]
        public bool Ssl { get; set; }

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

        /// <summary>
        /// <code>True</code> if watchdog is enabled, otherwise <code>False</code>.
        /// </summary>
        [JsonProperty("watchdog")]
        public bool Watchdog { get; set; }
    }
}
