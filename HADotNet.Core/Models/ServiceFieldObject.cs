namespace HADotNet.Core.Models
{
    /// <summary>
    /// Represents a signle field in a service call.
    /// </summary>
    public class ServiceFieldObject
    {
        /// <summary>
        /// Gets or sets the description of this field.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the example text for this field (may be <see langword="null" />).
        /// </summary>
        public string Example { get; set; }
    }
}
