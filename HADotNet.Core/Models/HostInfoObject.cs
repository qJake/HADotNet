using System.Collections.Generic;
using Newtonsoft.Json;

namespace HADotNet.Core.Models
{
    /// <summary>
    /// Represents Host info object.
    /// </summary>
    public class HostInfoObject
    {
        /// <summary>
        /// Gets or sets the chassis.
        /// </summary>
        [JsonProperty("chassis")]
        public string Chassis { get; set; }

        /// <summary>
        /// Gets or sets the CPE.
        /// </summary>
        [JsonProperty("cpe")]
        public string Cpe { get; set; }

        /// <summary>
        /// Gets or sets the deployment.
        /// </summary>
        [JsonProperty("deployment")]
        public string Deployment { get; set; }

        /// <summary>
        /// Gets or sets the disk free.
        /// </summary>
        [JsonProperty("disk_free")]
        public double DiskFree { get; set; }

        /// <summary>
        /// Gets or sets the disk total.
        /// </summary>
        [JsonProperty("disk_total")]
        public double DiskTotal { get; set; }

        /// <summary>
        /// Gets or sets the disk used.
        /// </summary>
        [JsonProperty("disk_used")]
        public double DiskUsed { get; set; }

        /// <summary>
        /// Gets or sets the features.
        /// </summary>
        [JsonProperty("features")]
        public IList<string> Features { get; set; }

        /// <summary>
        /// Gets or sets the hostname.
        /// </summary>
        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        /// <summary>
        /// Gets or sets the kernel.
        /// </summary>
        [JsonProperty("kernel")]
        public string Kernel { get; set; }

        /// <summary>
        /// Gets or sets the operating system.
        /// </summary>
        [JsonProperty("operating_system")]
        public string OperatingSystem { get; set; }
    }
}
