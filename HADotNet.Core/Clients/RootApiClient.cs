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
        /// <param name="client">The <see cref="HttpClient" /> preconfigured to communicate with a Home Assistant instance.</param>
        public RootApiClient(HttpClient client) : base(client) { }

        /// <summary>
        /// Retrieves the API status message for the Home Assistant instance, to ensure it is running.
        /// </summary>
        /// <returns>A <see cref="MessageObject" /> indicating the status of the connected instance.</returns>
        public async Task<MessageObject> GetStatusMessage() => await Get<MessageObject>("/api/");
    }
}
