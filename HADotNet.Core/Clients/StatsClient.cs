using System;
using System.Net.Http;
using System.Threading.Tasks;
using HADotNet.Core.Models;

namespace HADotNet.Core.Clients
{
    /// <summary>
    /// Provides access to the info API for retrieving statistics about Supervisor and Core.
    /// </summary>
    public class StatsClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatsClient" />.
        /// </summary>
        /// <param name="instance">The Home Assistant base instance URL.</param>
        /// <param name="apiKey">The Home Assistant long-lived access token.</param>
        /// <param name="httpClient">The Http client.</param>
        public StatsClient(Uri instance, string apiKey, HttpClient httpClient) : base(instance, apiKey, httpClient) { }

        /// <summary>
        /// Retrieves Supervisor information.
        /// </summary>
        /// <returns>A <see cref="StatsObject"/> representing Supervisor stats.</returns>
        public async Task<ResponseObject<StatsObject>> GetSupervisorStats() => await Get<ResponseObject<StatsObject>>("/api/hassio/supervisor/stats");

        /// <summary>
        /// Retrieves Core stats.
        /// </summary>
        /// <returns>A <see cref="StatsObject"/> representing Core stats.</returns>
        public async Task<ResponseObject<StatsObject>> GetCoreStats() => await Get<ResponseObject<StatsObject>>("/api/hassio/core/stats");
    }
}
