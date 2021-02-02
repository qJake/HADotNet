using HADotNet.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HADotNet.Core.Clients
{
    /// <summary>
    /// Provides access to the Logbook API for retrieving and querying for change events.
    /// </summary>
    public sealed class LogbookClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogbookClient" />.
        /// </summary>
        /// <param name="instance">The Home Assistant base instance URL.</param>
        /// <param name="apiKey">The Home Assistant long-lived access token.</param>
        public LogbookClient(Uri instance, string apiKey) : base(instance, apiKey) { }

        /// <summary>
        /// Retrieves a list of ALL logbook states for all entities for the past 1 day.
        /// </summary>
        /// <returns>A <see cref="List{LogbookObject}"/> representing a 24-hour history snapshot for all entities.</returns>
        public async Task<List<LogbookObject>> GetLogbookEntries() => await Get<List<LogbookObject>>("/api/logbook");

        /// <summary>
        /// Retrieves a list of ALL historical states for all entities for the specified day (<paramref name="startDate" /> + 24 hours). WARNING: On larger HA installs, this can return 300+ entities, over 4 MB of data, and take 20+ seconds.
        /// </summary>
        /// <returns>A <see cref="List{LogbookObject}"/> representing a 24-hour history snapshot starting from <paramref name="startDate" /> for all entities.</returns>
        public async Task<List<LogbookObject>> GetLogbookEntries(DateTimeOffset startDate) => await Get<List<LogbookObject>>($"/api/logbook/{startDate.UtcDateTime:yyyy-MM-dd\\THH:mm:ss\\+00\\:00}");

        /// <summary>
        /// Retrieves a list of ALL historical states for all entities for the specified time range, from <paramref name="startDate" /> to <paramref name="endDate" />. WARNING: On larger HA installs, for multiple days, this can return A LOT of data and potentially take a LONG time to return. Use with caution!
        /// </summary>
        /// <returns>A <see cref="List{LogbookObject}"/> representing a 24-hour history snapshot, from <paramref name="startDate" /> to <paramref name="endDate" />, for all entities.</returns>
        public async Task<List<LogbookObject>> GetLogbookEntries(DateTimeOffset startDate, DateTimeOffset endDate) => await Get<List<LogbookObject>>($"/api/logbook/{startDate.UtcDateTime:yyyy-MM-dd\\THH:mm:ss\\+00\\:00}?end_time={Uri.EscapeDataString(endDate.UtcDateTime.ToString("yyyy-MM-dd\\THH:mm:ss\\+00\\:00"))}");

        /// <summary>
        /// Retrieves a list of ALL historical states for all entities for the specified time range, from <paramref name="startDate" />, for the specified <paramref name="duration" />. WARNING: On larger HA installs, for multiple days, this can return A LOT of data and potentially take a LONG time to return. Use with caution!
        /// </summary>
        /// <returns>A <see cref="List{LogbookObject}"/> representing a 24-hour history snapshot, from <paramref name="startDate" />, for the specified <paramref name="duration" />, for all entities.</returns>
        public async Task<List<LogbookObject>> GetLogbookEntries(DateTimeOffset startDate, TimeSpan duration) => await GetLogbookEntries(startDate, startDate.Add(duration));

        /// <summary>
        /// Retrieves a list of historical states for the specified <paramref name="entityId" /> for the specified time range, from <paramref name="startDate" /> to <paramref name="endDate" />.
        /// </summary>
        /// <param name="entityId">The entity ID to filter on.</param>
        /// <param name="startDate">The earliest history entry to retrieve.</param>
        /// <param name="endDate">The most recent history entry to retrieve.</param>
        /// <returns>A <see cref="LogbookObject"/> of history snapshots for the specified <paramref name="entityId" />, from <paramref name="startDate" /> to <paramref name="endDate" />.</returns>
        public async Task<LogbookObject> GetLogbookEntries(string entityId, DateTimeOffset startDate, DateTimeOffset endDate) => (await Get<List<LogbookObject>>($"/api/logbook/{startDate.UtcDateTime:yyyy-MM-dd\\THH:mm:ss\\+00\\:00}?entity={entityId}&end_time={Uri.EscapeDataString(endDate.UtcDateTime.ToString("yyyy-MM-dd\\THH:mm:ss\\+00\\:00"))}")).FirstOrDefault();

        /// <summary>
        /// Retrieves a list of historical states for the specified <paramref name="entityId" /> for the past 1 day.
        /// </summary>
        /// <param name="entityId">The entity ID to retrieve state history for.</param>
        /// <returns>A <see cref="LogbookObject"/> representing a 24-hour history snapshot for the specified <paramref name="entityId" />.</returns>
        public async Task<LogbookObject> GetLogbookEntries(string entityId) => (await Get<List<LogbookObject>>($"/api/logbook?entity={entityId}")).FirstOrDefault();
    }
}
