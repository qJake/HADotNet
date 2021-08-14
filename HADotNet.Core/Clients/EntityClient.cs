using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HADotNet.Core.Models;

namespace HADotNet.Core.Clients
{
    /// <summary>
    /// Provides a wrapper around the States endpoint for retrieving entity info.
    /// </summary>
    public sealed class EntityClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityClient" />.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient" /> preconfigured to communicate with a Home Assistant instance.</param>
        public EntityClient(HttpClient client) : base(client) { }

        /// <summary>
        /// Retrieves a list of all current entity names (that have state) in the format "domain.name".
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}" /> of strings of all known entities (with state) at the time.</returns>
        public async Task<IEnumerable<string>> GetEntities() => (await Get<List<StateObject>>("/api/states")).Select(s => s.EntityId);

        /// <summary>
        /// Retrieves a list of entity names for a particular domain (that have state) in the format "domain.name".
        /// </summary>
        /// <param name="domainFilter">A domain name to filter the entity list to (e.g. "light").</param>
        /// <returns>An <see cref="IEnumerable{T}" /> of strings of all known entities (with state) at the time.</returns>
        public async Task<IEnumerable<string>> GetEntities(string domainFilter) => (await Get<List<StateObject>>("/api/states")).Where(s => s.EntityId.StartsWith(domainFilter + ".")).Select(s => s.EntityId);
    }
}
