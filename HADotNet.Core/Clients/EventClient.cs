using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HADotNet.Core.Models;

namespace HADotNet.Core.Clients
{
    /// <summary>
    /// Provides access to the event API for retrieving information about events and firing events.
    /// </summary>
    public sealed class EventClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventClient" />.
        /// </summary>
        /// <param name="instance">The Home Assistant base instance URL.</param>
        /// <param name="apiKey">The Home Assistant long-lived access token.</param>
        /// <param name="httpClient">The Http client.</param>
        public EventClient(Uri instance, string apiKey, HttpClient httpClient) : base(instance, apiKey, httpClient) { }

        /// <summary>
        /// Retrieves the current Home Assistant configuration object.
        /// </summary>
        /// <returns>A <see cref="ConfigurationObject" /> representing the current Home Assistant configuration.</returns>
        public async Task<List<EventObject>> GetEvents() => await Get<List<EventObject>>("/api/events");
    }
}
