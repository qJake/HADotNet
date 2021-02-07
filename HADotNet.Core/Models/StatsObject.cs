using Newtonsoft.Json;

namespace HADotNet.Core.Models
{
    /// <summary>
    /// Represents the stats object.
    /// </summary>
    public class StatsObject
    {
        /// <summary>
        /// Gets or sets the number of bulk reads.
        /// </summary>
        [JsonProperty("blk_read")]
        public long BlkRead { get; set; }

        /// <summary>
        /// Gets or sets the number of bulk writes.
        /// </summary>
        [JsonProperty("blk_write")]
        public long BlkWrite { get; set; }

        /// <summary>
        /// Gets or sets the CPU usage percent.
        /// </summary>
        [JsonProperty("cpu_percent")]
        public double CpuPercent { get; set; }

        /// <summary>
        /// Gets or sets the memory limit.
        /// </summary>
        [JsonProperty("memory_limit")]
        public long MemoryLimit { get; set; }

        /// <summary>
        /// Gets or sets the memory usage percent.
        /// </summary>
        [JsonProperty("memory_percent")]
        public double MemoryPercent { get; set; }

        /// <summary>
        /// Gets or sets the memory usage.
        /// </summary>
        [JsonProperty("memory_usage")]
        public long MemoryUsage { get; set; }

        /// <summary>
        /// Gets or sets the network rx.
        /// </summary>
        [JsonProperty("network_rx")]
        public long NetworkRx { get; set; }

        /// <summary>
        /// Gets or sets the network tx.
        /// </summary>
        [JsonProperty("network_tx")]
        public long NetworkTx { get; set; }
    }
}
