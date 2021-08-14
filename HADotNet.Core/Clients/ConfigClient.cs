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
        /// <param name="client">The <see cref="HttpClient" /> preconfigured to communicate with a Home Assistant instance.</param>
        public ConfigClient(HttpClient client) : base(client) { }

        /// <summary>
        /// Retrieves the current Home Assistant configuration object.
        /// </summary>
        /// <returns>A <see cref="ConfigurationObject" /> representing the current Home Assistant configuration.</returns>
        public async Task<ConfigurationObject> GetConfiguration() => await Get<ConfigurationObject>("/api/config");

        /// <summary>
        /// Performs a configuration check and returns the result.
        /// </summary>
        /// <returns>A <see cref="ConfigurationCheckResultObject" /> containing the results of the check, and any errors that occurred.</returns>
        public async Task<ConfigurationCheckResultObject> CheckConfiguration() => await Post<ConfigurationCheckResultObject>("/api/config/core/check_config", null);
    }
}
