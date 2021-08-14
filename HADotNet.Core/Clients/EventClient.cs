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
        /// <param name="client">The <see cref="HttpClient" /> preconfigured to communicate with a Home Assistant instance.</param>
        public EventClient(HttpClient client) : base(client) { }

        /// <summary>
        /// Retrieves a list of event types from the current Home Assistant instance.
        /// </summary>
        /// <returns>A list of <see cref="EventObject" /> representing the available event types.</returns>
        public async Task<List<EventObject>> GetEvents() => await Get<List<EventObject>>("/api/events");

        /// <summary>
        /// Fires an event of type <paramref name="eventType" /> on the event bus.
        /// </summary>
        /// <returns>An <see cref="EventFireResultObject" /> with a message on if the event fired successfully or not.</returns>
        public async Task<EventFireResultObject> FireEvent(string eventType, object payload) => await Post<EventFireResultObject>($"/api/events/{eventType}", payload);
    }
}
