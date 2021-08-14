using Newtonsoft.Json;

namespace HADotNet.Core.Models
{
    /// <summary>
    /// Represents the Home Assistant configuration object.
    /// </summary>
    public class ConfigurationCheckResultObject
    {
        /// <summary>
        /// Gets the errors that occurred. This value is <see langword="null" /> if <see cref="Result" /> is <c>valid</c>.
        /// </summary>
        [JsonProperty("errors")]
        public string Errors { get; set; }

        /// <summary>
        /// Gets the result of the configuration check. Valid values are <c>valid</c> and <c>invalid</c>.
        /// </summary>
        [JsonProperty("result")]
        public string Result { get; set; }
        
        /// <summary>
        /// Gets a string representation of this object.
        /// </summary>
        public override string ToString() => $"Configuration check result (status: {Result})";
    }
}
