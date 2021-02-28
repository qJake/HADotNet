using System;
using System.Net.Http;
using System.Threading.Tasks;
using HADotNet.Core.Models;

namespace HADotNet.Core.Clients
{
    /// <summary>
    /// Provides access to the error log API for retrieving the current error log messages.
    /// </summary>
    public sealed class ErrorLogClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorLogClient" />.
        /// </summary>
        /// <param name="instance">The Home Assistant base instance URL.</param>
        /// <param name="apiKey">The Home Assistant long-lived access token.</param>
        /// <param name="httpClient">The Http client.</param>
        public ErrorLogClient(Uri instance, string apiKey, HttpClient httpClient) : base(instance, apiKey, httpClient) { }

        /// <summary>
        /// Retrieves a list of error log entries.
        /// </summary>
        /// <returns>An <see cref="ErrorLogObject" /> containing error log entries.</returns>
        public async Task<ErrorLogObject> GetErrorLogEntries() => new ErrorLogObject(await Get<string>("/api/error_log"));
    }
}
