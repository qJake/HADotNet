namespace HADotNet.Core.Models
{
    /// <summary>
    /// Represents the result of an event firing.
    /// </summary>
    public class EventFireResultObject
    {
        /// <summary>
        /// Gets the resulting message from the event fire command.
        /// </summary>
        public string Message { get; set; }
    }
}
