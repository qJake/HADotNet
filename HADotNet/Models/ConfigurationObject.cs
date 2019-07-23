using Newtonsoft.Json;
using System.Collections.Generic;

namespace HADotNet.Core.Models
{
    /// <summary>
    /// Represents the Home Assistant configuration object.
    /// </summary>
    public class ConfigurationObject
    {
        /// <summary>
        /// Gets the list of components loaded, in the [domain] or [domain].[component] format.
        /// </summary>
        public List<string> Components { get; internal set; }

        /// <summary>
        /// Gets or sets the relative path to the config directory (usually "/config").
        /// </summary>
        [JsonProperty("config_dir")]
        public string ConfigDirectory { get; set; }

        /// <summary>
        /// Gets or sets the config source, or type of configuration file (usually "yaml").
        /// </summary>
        [JsonProperty("config_source")]
        public string ConfigSource { get; set; }

        /// <summary>
        /// Gets or sets the elevation (in meters) of the current location.
        /// </summary>
        public int Elevation { get; set; }

        /// <summary>
        /// Gets or sets the latitude of the current location.
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude of the current location.
        /// </summary>
        public decimal Longitude { get; set; }

        /// <summary>
        /// Gets or sets the location's friendly name.
        /// </summary>
        [JsonProperty("location_name")]
        public string LocationName { get; set; }

        /// <summary>
        /// Gets or sets the time zone name (in "tz database" name format, see https://en.wikipedia.org/wiki/List_of_tz_database_time_zones).
        /// </summary>
        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }

        /// <summary>
        /// Gets information about the various measurement unit preferences.
        /// </summary>
        [JsonProperty("unit_system")]
        public UnitSystemObject UnitSystem { get; internal set; }

        /// <summary>
        /// Gets the version of Home Assistant that is currently running (e.g. 0.96.1).
        /// </summary>
        public string Version { get; internal set; }

        /// <summary>
        /// Gets a list of relative paths that are approved to be exposed externally (e.g. /config/www).
        /// </summary>
        [JsonProperty("whitelist_external_dirs")]
        public List<string> WhitelistedExternalDirs { get; internal set; }

    }
}
