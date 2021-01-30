using System;
using System.Threading.Tasks;
using HADotNet.Core.Models;

namespace HADotNet.Core.Clients
{
    /// <summary>
    /// Provides access to the info API for retrieving information about Supervisor, Core and Host.
    /// </summary>
    public class InfoClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InfoClient" />.
        /// </summary>
        /// <param name="instance">The Home Assistant base instance URL.</param>
        /// <param name="apiKey">The Home Assistant long-lived access token.</param>
        public InfoClient(Uri instance, string apiKey) : base(instance, apiKey) { }

        /// <summary>
        /// Retrieves Supervisor information.
        /// </summary>
        /// <returns>A <see cref="SupervisorInfoObject"/> representing Supervisor informatio.</returns>
        public async Task<ResponseObject<SupervisorInfoObject>> GetSupervisorInfo() => await Get<ResponseObject<SupervisorInfoObject>>("/api/hassio/supervisor/info");

        /// <summary>
        /// Retrieves Host information.
        /// </summary>
        /// <returns>A <see cref="HostInfoObject"/> representing Host informatio.</returns>
        public async Task<ResponseObject<HostInfoObject>> GetHostInfo() => await Get<ResponseObject<HostInfoObject>>("/api/hassio/host/info");

        /// <summary>
        /// Retrieves Core information.
        /// </summary>
        /// <returns>A <see cref="CoreInfoObject"/> representing Host informatio.</returns>
        public async Task<ResponseObject<CoreInfoObject>> GetCoreInfo() => await Get<ResponseObject<CoreInfoObject>>("/api/hassio/core/info");
    }
}
