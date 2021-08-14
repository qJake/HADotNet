using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HADotNet.Core.Models;

namespace HADotNet.Core.Clients
{
    /// <summary>
    /// Provides access to the states API for retrieving information about the current state of entities.
    /// </summary>
    public sealed class StatesClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatesClient" />.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient" /> preconfigured to communicate with a Home Assistant instance.</param>
        public StatesClient(HttpClient client) : base(client) { }

        /// <summary>
        /// Retrieves a list of current entities and their states.
        /// </summary>
        /// <returns>A <see cref="List{StateObject}" /> representing the current state.</returns>
        public async Task<List<StateObject>> GetStates() => await Get<List<StateObject>>("/api/states");

        /// <summary>
        /// Retrieves the state of an entity by its ID.
        /// </summary>
        /// <returns>A <see cref="StateObject" /> representing the current state of the requested <paramref name="entityId" />.</returns>
        public async Task<StateObject> GetState(string entityId) => await Get<StateObject>($"/api/states/{entityId}");

        /// <summary>
        /// Sets the state of an entity. If the entity does not exist, it will be created.
        /// </summary>
        /// <param name="entityId">The entity ID of the state to change.</param>
        /// <param name="newState">The new state value.</param>
        /// <param name="setAttributes">Optional. The attributes to set.</param>
        /// <returns>A <see cref="StateObject" /> representing the updated state of the updated <paramref name="entityId" />.</returns>
        public async Task<StateObject> SetState(string entityId, string newState, Dictionary<string, object> setAttributes = null) => await Post<StateObject>($"/api/states/{entityId}", new { state = newState, attributes = setAttributes });
    }
}
