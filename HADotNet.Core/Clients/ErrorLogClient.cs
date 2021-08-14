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
        /// <param name="client">The <see cref="HttpClient" /> preconfigured to communicate with a Home Assistant instance.</param>
        public ErrorLogClient(HttpClient client) : base(client) { }

        /// <summary>
        /// Retrieves a list of error log entries.
        /// </summary>
        /// <returns>An <see cref="ErrorLogObject" /> containing error log entries.</returns>
        public async Task<ErrorLogObject> GetErrorLogEntries() => new ErrorLogObject(await Get<string>("/api/error_log"));
    }
}
