using System;
using System.Net.Http;

namespace HADotNet.Core.Tests.Infrastructure
{
    public sealed class DefaultHttpClientFactory : IHttpClientFactory
    {
        private static readonly Lazy<IHttpClientFactory> _httpClientFactoryLazy =
            new Lazy<IHttpClientFactory>(() => new DefaultHttpClientFactory());

        private static readonly Lazy<HttpClient> _httpClientLazy =
            new Lazy<HttpClient>(() => new HttpClient());

        // NOTE: This will always return the same HttpClient instance.
        public HttpClient CreateClient(string name) => _httpClientLazy.Value;

        public static IHttpClientFactory GetInstance() => _httpClientFactoryLazy.Value;
    }
}
