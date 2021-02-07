using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HADotNet.Core.Models;

namespace HADotNet.Core.Clients
{
    /// <summary>
    /// Provides access to the calendar API for retrieving information about calendar entries.
    /// </summary>
    public sealed class CalendarClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CalendarClient" />.
        /// </summary>
        /// <param name="instance">The Home Assistant base instance URL.</param>
        /// <param name="apiKey">The Home Assistant long-lived access token.</param>
        /// <param name="httpClient">The Http client.</param>
        public CalendarClient(Uri instance, string apiKey, HttpClient httpClient) : base(instance, apiKey, httpClient) { }

        /// <summary>
        /// Retrieves a list of current and future calendar items, from now until the specified <paramref name="daysFromNow" />. The maximum number of results is driven by the "max_results" configuration option in the calendar config.
        /// </summary>
        /// <param name="calendarEntityName">The full name of the calendar entity. If this paramter does not start with "calendar.", it will be prepended automatically.</param>
        /// <param name="daysFromNow">Optional, defaults to 30. The number of days from the current point in time to retrieve calendar items for.</param>
        /// <returns>A <see cref="List{CalendarObject}" /> representing the calendar items found.</returns>
        public async Task<List<CalendarObject>> GetEvents(string calendarEntityName, int daysFromNow = 30) => await GetEvents(calendarEntityName, DateTimeOffset.Now, DateTimeOffset.Now.AddDays(daysFromNow));

        /// <summary>
        /// Retrieves a list of current and future calendar items, between the <paramref name="start" /> and <paramref name="end" /> parameters. The maximum number of results is driven by the "max_results" configuration option in the calendar config.
        /// </summary>
        /// <param name="calendarEntityName">The full name of the calendar entity. If this paramter does not start with "calendar.", it will be prepended automatically.</param>
        /// <param name="start">The start date/time to search.</param>
        /// <param name="end">The end date/time to search.</param>
        /// <returns>A <see cref="List{CalendarObject}" /> representing the calendar items found.</returns>
        public async Task<List<CalendarObject>> GetEvents(string calendarEntityName, DateTimeOffset start, DateTimeOffset end) => await Get<List<CalendarObject>>($"/api/calendars/{(calendarEntityName.StartsWith("calendar.") ? calendarEntityName : "calendar." + calendarEntityName)}?start={start:yyyy-MM-dd\\THH:mm:ss}Z&end={end:yyyy-MM-dd\\THH:mm:ss}Z");
    }
}
