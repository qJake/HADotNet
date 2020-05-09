using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace HADotNet.Core
{
    /// <summary>
    /// Represents the base client from which all other API clients derive.
    /// </summary>
    public abstract class BaseClient
    {
        /// <summary>
        /// Gets or sets the Rest client.
        /// </summary>
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
        protected async Task<T> Get<T>(string path) where T : class
        {
            var req = new RestRequest(path);
            var resp = await Client.ExecuteGetAsync(req);

            if (!string.IsNullOrWhiteSpace(resp.Content) && (resp.StatusCode == HttpStatusCode.OK || resp.StatusCode == HttpStatusCode.Created))
            {
                // Weird case for strings - return as-is
                if (typeof(T).IsAssignableFrom(typeof(string)))
                {
                    return resp.Content as T;
                }

                return JsonConvert.DeserializeObject<T>(resp.Content);
            }

            throw new Exception($"Unexpected response code {(int)resp.StatusCode} from Home Assistant API endpoint {path}.");
        }

        /// <summary>
        /// Performs a POST request on the specified path.
        /// </summary>
        /// <typeparam name="T">The type of object expected back.</typeparam>
        /// <param name="path">The path to post to.</param>
        /// <param name="body">The body contents to serialize and include.</param>
        /// <param name="isRawBody"><see langword="true" /> if the body should be interpereted as a pre-built JSON string, or <see langword="false" /> if it should be serialized.</param>
        /// <returns></returns>
        protected async Task<T> Post<T>(string path, object body, bool isRawBody = false) where T : class
        {
            var req = new RestRequest(path);
            if (body != null)
            {
                if (isRawBody)
                {
                    req.AddParameter("application/json", body.ToString(), ParameterType.RequestBody);
                }
                else
                {
                    req.AddParameter("application/json", JsonConvert.SerializeObject(body), ParameterType.RequestBody);
                }
            }
            var resp = await Client.ExecutePostAsync(req);

            if (!string.IsNullOrWhiteSpace(resp.Content) && (resp.StatusCode == HttpStatusCode.OK || resp.StatusCode == HttpStatusCode.Created))
            {
                // Weird case for strings - return as-is
                if (typeof(T).IsAssignableFrom(typeof(string)))
                {
                    return resp.Content as T;
                }

                return JsonConvert.DeserializeObject<T>(resp.Content);
            }

            throw new Exception($"Unexpected response code {(int)resp.StatusCode} from Home Assistant API endpoint {path}.");
        }

        /// <summary>
        /// Performs a DELETE request on the specified path.
        /// </summary>
        /// <typeparam name="T">The type of data to deserialize and return.</typeparam>
        /// <param name="path">The relative API endpoint path.</param>
        /// <returns>The deserialized data of type <typeparamref name="T" />.</returns>
        protected async Task<T> Delete<T>(string path) where T : class
        {
            var req = new RestRequest(path, Method.DELETE);

            var resp = await Client.ExecuteAsync(req);

            if (!string.IsNullOrWhiteSpace(resp.Content) && (resp.StatusCode == HttpStatusCode.OK || resp.StatusCode == HttpStatusCode.NoContent))
            {
                // Weird case for strings - return as-is
                if (typeof(T).IsAssignableFrom(typeof(string)))
                {
                    return resp.Content as T;
                }

                return JsonConvert.DeserializeObject<T>(resp.Content);
            }

            throw new Exception($"Unexpected response code {(int)resp.StatusCode} from Home Assistant API endpoint {path}.");
        }

        /// <summary>
        /// Performs a DELETE request on the specified path.
        /// </summary>
        /// <param name="path">The relative API endpoint path.</param>
        protected async Task Delete(string path)
        {
            var req = new RestRequest(path, Method.DELETE);

            var resp = await Client.ExecuteAsync(req);

            if (!(resp.StatusCode == HttpStatusCode.OK || resp.StatusCode == HttpStatusCode.NoContent))
            {
                throw new Exception($"Unexpected response code {(int)resp.StatusCode} from Home Assistant API endpoint {path}.");
            }
        }
    }
}
