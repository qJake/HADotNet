namespace HADotNet.Core.Models
{
    /// <summary>
    /// Represents a basic message object returned from the server (e.g. an object with a "message" property).
    /// </summary>
    public class MessageObject
    {
        /// <summary>
        /// Gets or sets the message for this message object.
        /// </summary>
        public string Message { get; set; }
    }
}
