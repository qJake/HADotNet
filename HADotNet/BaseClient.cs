using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace HADotNet.Core
{
    /// <summary>
    /// Represents the base client from which all other API clients derive.
    /// </summary>
    public abstract class BaseClient
    {
        protected RestClient Client { get; set; }

        /// <summary>
        /// Initializes a new <see cref="BaseClient" /> instance.
        /// </summary>
        /// <param name="instance">The Home Assistant instance URL.</param>
        /// <param name="apiKey">The long-lived Home Assistant API key.</param>
        protected BaseClient(Uri instance, string apiKey)
        {
            Client = new RestClient(instance);
            Client.AddDefaultHeader("Authorization", $"Bearer {apiKey}");
        }

        /// <summary>
        /// Performs a GET request on the specified path.
        /// </summary>
        /// <typeparam name="T">The type of data to deserialize and return.</typeparam>
        /// <param name="path">The relative API endpoint path.</param>
        /// <returns>The deserialized data of type <typeparamref name="T" />.</returns>
        protected async Task<T> Get<T>(string path)
        {
            var req = new RestRequest(path);
            var resp = await Client.ExecuteGetTaskAsync(req);

            if (!string.IsNullOrWhiteSpace(resp.Content) && (resp.StatusCode == HttpStatusCode.OK || resp.StatusCode == HttpStatusCode.Created))
            {
                return JsonConvert.DeserializeObject<T>(resp.Content);
            }

            throw new Exception($"Unexpected response code {(int)resp.StatusCode} from Home Assistant API endpoint {path}.");
        }

        protected async Task<T> Post<T>(string path, object body)
        {
            var req = new RestRequest(path);
            req.AddJsonBody(body);
            var resp = await Client.ExecutePostTaskAsync(req);

            if (!string.IsNullOrWhiteSpace(resp.Content) && (resp.StatusCode == HttpStatusCode.OK || resp.StatusCode == HttpStatusCode.Created))
            {
                return JsonConvert.DeserializeObject<T>(resp.Content);
            }

            throw new Exception($"Unexpected response code {(int)resp.StatusCode} from Home Assistant API endpoint {path}.");
        }
    }
}
