using HADotNet.Core.Models;
using System;
using System.Threading.Tasks;

namespace HADotNet.Core.Clients
{
    /// <summary>
    /// Provides access to the configuration API for retrieving the current Home Assistant configuration.
    /// </summary>
    public sealed class ConfigClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigClient" />.
        /// </summary>
        /// <param name="instance">The Home Assistant base instance URL.</param>
        /// <param name="apiKey">The Home Assistant long-lived access token.</param>
        public ConfigClient(Uri instance, string apiKey) : base(instance, apiKey) { }

        /// <summary>
        /// Retrieves the current Home Assistant configuration object.
        /// </summary>
        /// <returns>A <see cref="ConfigurationObject" /> representing the current Home Assistant configuration.</returns>
        public async Task<ConfigurationObject> GetConfiguration() => await Get<ConfigurationObject>("/api/config");
    }
}
