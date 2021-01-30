using Newtonsoft.Json;

namespace HADotNet.Core.Models
{
    /// <summary>
    /// Represents Home Assistant response.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseObject<T>
    {
        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        [JsonProperty("result")]
        public string Result { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        [JsonProperty("data")]
        public T Data { get; set; }
    }
}
