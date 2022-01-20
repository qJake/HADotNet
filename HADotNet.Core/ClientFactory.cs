using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace HADotNet.Core
{
    /// <summary>
    /// Provides a factory which can instantiate API clients (useful in DI scenarios, for example).
    /// </summary>
    public static class ClientFactory
    {
        /// <summary>
        /// Gets whether or not the Client Factory has been initialized.
        /// </summary>
        public static bool IsInitialized { get; internal set; }

        /// <summary>
        /// Gets the <see cref="HttpClient" /> instance configured for this ClientFactory. To reconfigure the HttpClient, call <see cref="Initialize(string, string)" /> again.
        /// </summary>
        public static HttpClient Client { get; private set; }

        /// <summary>
        /// Initializes the client factory with the specified <paramref name="instanceAddress" /> and <paramref name="apiKey" /> which are forwarded to clients instantiated from this factory.
        /// </summary>
        /// <param name="instanceAddress">The Home Assistant base instance address (do not include /api/).</param>
        /// <param name="apiKey">The Home Assistant long-lived access token.</param>
        public static void Initialize(Uri instanceAddress, string apiKey)
        {
            Client = new HttpClient
            {
                BaseAddress = instanceAddress,
                DefaultRequestHeaders =
                {
                    Authorization = new AuthenticationHeaderValue("Bearer", apiKey),
                    AcceptEncoding =
                    {
                        new StringWithQualityHeaderValue("identity")
                    }
                }
            };
            IsInitialized = true;
        }

        /// <summary>
        /// Initializes the client factory with the specified <paramref name="instanceAddress" /> and <paramref name="apiKey" /> which are forwarded to clients instantiated from this factory.
        /// <para>Allows specifying the <paramref name="handler" /> to allow further configuring.</para>
        /// </summary>
        /// <param name="instanceAddress"></param>
        /// <param name="apiKey"></param>
        /// <param name="handler"></param>
        public static void Initialize(Uri instanceAddress, string apiKey, HttpClientHandler handler)
        {
            Client = new HttpClient(handler)
            {
                BaseAddress = instanceAddress,
                DefaultRequestHeaders =
                {
                    Authorization = new AuthenticationHeaderValue("Bearer", apiKey),
                    AcceptEncoding =
                    {
                        new StringWithQualityHeaderValue("identity")
                    }
                }
            };
            IsInitialized = true;
        }

        /// <summary>
        /// Initializes the client factory with the specified <paramref name="instanceAddress" /> and <paramref name="apiKey" /> which are forwarded to clients instantiated from this factory.
        /// </summary>
        /// <param name="instanceAddress">The Home Assistant base instance address (do not include /api/).</param>
        /// <param name="apiKey">The Home Assistant long-lived access token.</param>
        public static void Initialize(string instanceAddress, string apiKey) => Initialize(new Uri(instanceAddress), apiKey);

        /// <summary>
        /// Initializes the client factory with the specified <paramref name="instanceAddress" /> and <paramref name="apiKey" /> which are forwarded to clients instantiated from this factory.
        /// <para>Allows specifying the <paramref name="handler" /> to allow further configuring.</para>
        /// </summary>
        /// <param name="instanceAddress"></param>
        /// <param name="apiKey"></param>
        /// <param name="handler"></param>
        public static void Initialize(string instanceAddress, string apiKey, HttpClientHandler handler) => Initialize(new Uri(instanceAddress), apiKey, handler);

        /// <summary>
        /// Resets the Client Factory to its initial state (not initialized).
        /// </summary>
        public static void Reset()
        {
            IsInitialized = false;
            try
            {
                Client?.Dispose();
            }
            catch
            {
                // Can't dispose? Oh well.
            }
            Client = null;
        }

        /// <summary>
        /// Retrieves a new instance of a client by type, preconfigured with the same <see cref="HttpClient" /> as this <see cref="ClientFactory" /> (from the last time <see cref="Initialize(Uri, string)" /> was called).
        /// </summary>
        /// <typeparam name="TClient">The type of client to get.</typeparam>
        /// <exception cref="Exception">Thrown if this <see cref="ClientFactory" /> is not initialized (call <see cref="Initialize(Uri, string)" /> first).</exception>
        /// <returns>A new instance of the specified <typeparamref name="TClient" /> type.</returns>
        public static TClient GetClient<TClient>() where TClient : BaseClient => (TClient)Activator.CreateInstance(typeof(TClient), Client);

    }
}
