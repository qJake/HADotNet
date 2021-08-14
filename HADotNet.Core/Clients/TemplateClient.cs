using System.Net.Http;
using System.Threading.Tasks;

namespace HADotNet.Core.Clients
{
    /// <summary>
    /// Provides access to the template API for rendering Home Assistant templates.
    /// </summary>
    public sealed class TemplateClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateClient" />.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient" /> preconfigured to communicate with a Home Assistant instance.</param>
        public TemplateClient(HttpClient client) : base(client) { }

        /// <summary>
        /// Renders a template and returns the resulting output as a string.
        /// </summary>
        /// <returns>A string of the rendered template output.</returns>
        public async Task<string> RenderTemplate(string template) => await Post<string>("/api/template", new { template });
    }
}
