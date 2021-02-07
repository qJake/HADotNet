using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HADotNet.Core.Models;

namespace HADotNet.Core.Clients
{
    /// <summary>
    /// Provides access to the history API for retrieving and querying for historical state information.
    /// </summary>
    public sealed class HistoryClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HistoryClient" />.
        /// </summary>
        /// <param name="instance">The Home Assistant base instance URL.</param>
        /// <param name="apiKey">The Home Assistant long-lived access token.</param>
        /// <param name="httpClient">The Http client.</param>
        public HistoryClient(Uri instance, string apiKey, HttpClient httpClient) : base(instance, apiKey, httpClient) { }

        /// <summary>
        /// Retrieves a list of ALL historical states for all entities for the past 1 day. WARNING: On larger HA installs, this can return 300+ entities, over 4 MB of data, and take 20+ seconds.
        /// </summary>
        /// <returns>A <see cref="List{HistoryList}"/> representing a 24-hour history snapshot for all entities.</returns>
        public async Task<List<HistoryList>> GetHistory() => await Get<List<HistoryList>>("/api/history/period");

        /// <summary>
        /// Retrieves a list of ALL historical states for all entities for the specified day (<paramref name="startDate" /> + 24 hours). WARNING: On larger HA installs, this can return 300+ entities, over 4 MB of data, and take 20+ seconds.
        /// </summary>
        /// <returns>A <see cref="List{HistoryList}"/> representing a 24-hour history snapshot starting from <paramref name="startDate" /> for all entities.</returns>
        public async Task<List<HistoryList>> GetHistory(DateTimeOffset startDate) => await Get<List<HistoryList>>($"/api/history/period/{startDate.UtcDateTime:yyyy-MM-dd\\THH:mm:ss\\+00\\:00}");

        /// <summary>
        /// Retrieves a list of ALL historical states for all entities for the specified time range, from <paramref name="startDate" /> to <paramref name="endDate" />. WARNING: On larger HA installs, for multiple days, this can return A LOT of data and potentially take a LONG time to return. Use with caution!
        /// </summary>
        /// <returns>A <see cref="List{HistoryList}"/> representing a 24-hour history snapshot, from <paramref name="startDate" /> to <paramref name="endDate" />, for all entities.</returns>
        public async Task<List<HistoryList>> GetHistory(DateTimeOffset startDate, DateTimeOffset endDate) => await Get<List<HistoryList>>($"/api/history/period/{startDate.UtcDateTime:yyyy-MM-dd\\THH:mm:ss\\+00\\:00}?end_time={Uri.EscapeDataString(endDate.UtcDateTime.ToString("yyyy-MM-dd\\THH:mm:ss\\+00\\:00"))}");

        /// <summary>
        /// Retrieves a list of ALL historical states for all entities for the specified time range, from <paramref name="startDate" />, for the specified <paramref name="duration" />. WARNING: On larger HA installs, for multiple days, this can return A LOT of data and potentially take a LONG time to return. Use with caution!
        /// </summary>
        /// <returns>A <see cref="List{HistoryList}"/> representing a 24-hour history snapshot, from <paramref name="startDate" />, for the specified <paramref name="duration" />, for all entities.</returns>
        public async Task<List<HistoryList>> GetHistory(DateTimeOffset startDate, TimeSpan duration) => await GetHistory(startDate, startDate.Add(duration));

        /// <summary>
        /// Retrieves a list of historical states for the specified <paramref name="entityId" /> for the specified time range, from <paramref name="startDate" /> to <paramref name="endDate" />.
        /// </summary>
        /// <param name="entityId">The entity ID to filter on.</param>
        /// <param name="startDate">The earliest history entry to retrieve.</param>
        /// <param name="endDate">The most recent history entry to retrieve.</param>
        /// <returns>A <see cref="HistoryList"/> of history snapshots for the specified <paramref name="entityId" />, from <paramref name="startDate" /> to <paramref name="endDate" />.</returns>
        public async Task<HistoryList> GetHistory(string entityId, DateTimeOffset startDate, DateTimeOffset endDate) => (await Get<List<HistoryList>>($"/api/history/period/{startDate.UtcDateTime:yyyy-MM-dd\\THH:mm:ss\\+00\\:00}?filter_entity_id={entityId}&end_time={Uri.EscapeDataString(endDate.UtcDateTime.ToString("yyyy-MM-dd\\THH:mm:ss\\+00\\:00"))}")).FirstOrDefault();

        /// <summary>
        /// Retrieves a list of historical states for the specified <paramref name="entityId" /> for the past 1 day.
        /// </summary>
        /// <param name="entityId">The entity ID to retrieve state history for.</param>
        /// <returns>A <see cref="HistoryList"/> representing a 24-hour history snapshot for the specified <paramref name="entityId" />.</returns>
        public async Task<HistoryList> GetHistory(string entityId) => (await Get<List<HistoryList>>($"/api/history/period?filter_entity_id={entityId}")).FirstOrDefault();
    }
}
