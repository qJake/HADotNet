using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HADotNet.Core
{
    /// <summary>
    /// Represents the base client from which all other API clients derive.
    /// </summary>
    public abstract class BaseClient
    {
        private const string JSON_MEDIA_TYPE = "application/json";

        /// <summary>
        /// Gets the static HttpClient instance.
        /// </summary>
        protected static HttpClient Client { get; set; }

        /// <summary>
        /// Initializes a new <see cref="BaseClient" /> instance.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient" /> preconfigured to communicate with a Home Assistant instance.</param>
        protected BaseClient(HttpClient client)
        {
            Client = client;
        }

        /// <summary>
        /// Performs a GET request on the specified path.
        /// </summary>
        /// <typeparam name="T">The type of data to deserialize and return.</typeparam>
        /// <param name="path">The relative API endpoint path.</param>
        /// <returns>The deserialized data of type <typeparamref name="T" />.</returns>
        protected async Task<T> Get<T>(string path) where T : class
        {
            var resp = await Client.GetAsync(path);
            resp.EnsureSuccessStatusCode();

            if (typeof(T).IsArray && typeof(T).GetElementType().IsAssignableFrom(typeof(byte)))
            {
                // byte[]
                return (await resp.Content.ReadAsByteArrayAsync()) as T;
            }

            var respContent = await resp.Content?.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(respContent))
            {
                throw new Exception($"Response content from endpoint {path} was empty.");
            }

            if (typeof(T).IsAssignableFrom(typeof(string)))
            {
                // string
                return respContent as T;
            }

            return JsonConvert.DeserializeObject<T>(respContent);
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
            var resp = await Client.PostAsync(path, new StringContent(isRawBody ? (body?.ToString() ?? "") : JsonConvert.SerializeObject(body ?? ""), Encoding.UTF8, JSON_MEDIA_TYPE));
            resp.EnsureSuccessStatusCode();

            var respContent = await resp.Content?.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(respContent))
            {
                throw new Exception($"Response content from endpoint {path} was empty.");
            }

            if (typeof(T).IsAssignableFrom(typeof(string)))
            {
                return respContent as T;
            }

            return JsonConvert.DeserializeObject<T>(respContent);
        }

        /// <summary>
        /// Performs a DELETE request on the specified path.
        /// </summary>
        /// <typeparam name="T">The type of data to deserialize and return.</typeparam>
        /// <param name="path">The relative API endpoint path.</param>
        /// <returns>The deserialized data of type <typeparamref name="T" />.</returns>
        protected async Task<T> Delete<T>(string path) where T : class
        {
            var resp = await Client.DeleteAsync(path);
            resp.EnsureSuccessStatusCode();

            var respContent = await resp.Content?.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(respContent))
            {
                throw new Exception($"Response content from endpoint {path} was empty.");
            }

            if (typeof(T).IsAssignableFrom(typeof(string)))
            {
                return respContent as T;
            }

            return JsonConvert.DeserializeObject<T>(respContent);
        }

        /// <summary>
        /// Performs a DELETE request on the specified path.
        /// </summary>
        /// <param name="path">The relative API endpoint path.</param>
        protected async Task Delete(string path)
        {
            var resp = await Client.DeleteAsync(path);
            resp.EnsureSuccessStatusCode();
        }
    }
}
