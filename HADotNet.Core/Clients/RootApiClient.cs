using System;
using System.Net.Http;
using System.Threading.Tasks;
using HADotNet.Core.Models;

namespace HADotNet.Core.Clients
{
    /// <summary>
    /// Provides access to the root API call (located at /api/) to ensure the API is working normally.
    /// </summary>
    public class RootApiClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RootApiClient" />.
        /// </summary>
        /// <param name="instance">The Home Assistant base instance URL.</param>
        /// <param name="apiKey">The Home Assistant long-lived access token.</param>
        /// <param name="httpClient">The Http client.</param>
        public RootApiClient(Uri instance, string apiKey, HttpClient httpClient) : base(instance, apiKey, httpClient) { }

        /// <summary>
        /// Retrieves the API status message for the Home Assistant instance, to ensure it is running.
        /// </summary>
        /// <returns>A <see cref="MessageObject" /> indicating the status of the connected instance.</returns>
        public async Task<MessageObject> GetStatusMessage() => await Get<MessageObject>("/api/");
    }
}
