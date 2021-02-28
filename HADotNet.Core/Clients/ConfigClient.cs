using System;
using System.Net.Http;
using System.Threading.Tasks;
using HADotNet.Core.Models;

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
        /// <param name="httpClient">The Http client.</param>
        public ConfigClient(Uri instance, string apiKey, HttpClient httpClient) : base(instance, apiKey, httpClient) { }

        /// <summary>
        /// Retrieves the current Home Assistant configuration object.
        /// </summary>
        /// <returns>A <see cref="ConfigurationObject" /> representing the current Home Assistant configuration.</returns>
        public async Task<ConfigurationObject> GetConfiguration() => await Get<ConfigurationObject>("/api/config");
    }
}
