using HADotNet.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HADotNet.Core.Clients
{
    /// <summary>
    /// Provides access to the service API for retrieving information about services and calling services.
    /// </summary>
    public sealed class StatesClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatesClient" />.
        /// </summary>
        /// <param name="instance">The Home Assistant base instance URL.</param>
        /// <param name="apiKey">The Home Assistant long-lived access token.</param>
        public StatesClient(Uri instance, string apiKey) : base(instance, apiKey) { }

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
    }
}
