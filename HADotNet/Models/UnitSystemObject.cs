namespace HADotNet.Core.Models
{
    /// <summary>
    /// Represents the Unit System, part of the <see cref="ConfigurationObject" />.
    /// </summary>
    public class UnitSystemObject
    {
        /// <summary>
        /// The length unit (e.g. mi, km).
        /// </summary>
        public string Length { get; set; }

        /// <summary>
        /// The mass unit (e.g. lb, kg).
        /// </summary>
        public string Mass { get; set; }

        /// <summary>
        /// The pressure unit (e.g. psi, bar).
        /// </summary>
        public string Pressure { get; set; }

        /// <summary>
        /// The temperature unit including degree symbol (e.g. °F, °C).
        /// </summary>
        public string Temperature { get; set; }

        /// <summary>
        /// The volume unit (e.g. gal, L).
        /// </summary>
        public string Volume { get; set; }
    }
}
