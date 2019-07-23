using Newtonsoft.Json;

namespace HADotNet.Core.Models
{
    public class MessageObject
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
