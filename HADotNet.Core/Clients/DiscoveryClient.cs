using System;
using System.Net.Http;
using System.Threading.Tasks;
using HADotNet.Core.Models;

namespace HADotNet.Core.Clients
{
    /// <summary>
    /// Provides access to the discovery API for retrieving the current Home Assistant instance information.
    /// </summary>
    public sealed class DiscoveryClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiscoveryClient" />.
        /// </summary>
        /// <param name="instance">The Home Assistant base instance URL.</param>
        /// <param name="apiKey">The Home Assistant long-lived access token.</param>
        /// <param name="httpClient">The Http client.</param>
        public DiscoveryClient(Uri instance, string apiKey, HttpClient httpClient) : base(instance, apiKey, httpClient) { }

        /// <summary>
        /// Retrieves the current Home Assistant discovery object.
        /// </summary>
        /// <returns>A <see cref="DiscoveryObject" /> representing the current Home Assistant instance information.</returns>
        public async Task<DiscoveryObject> GetDiscoveryInfo() => await Get<DiscoveryObject>("/api/discovery_info");
    }
}
