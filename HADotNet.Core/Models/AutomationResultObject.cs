using Newtonsoft.Json;

namespace HADotNet.Core.Models
{
    /// <summary>
    /// Represents the automation result.
    /// </summary>
    public class AutomationResultObject
    {
        /// <summary>
        /// Gets or sets the automation result.
        /// </summary>
        [JsonProperty("result")]
        public string Result { get; set; }
    }
}
