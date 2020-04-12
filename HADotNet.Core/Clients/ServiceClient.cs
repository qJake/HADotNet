using HADotNet.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HADotNet.Core.Clients
{
    /// <summary>
    /// Provides access to the service API for retrieving information about services and calling services.
    /// </summary>
    public sealed class ServiceClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceClient" />.
        /// </summary>
        /// <param name="instance">The Home Assistant base instance URL.</param>
        /// <param name="apiKey">The Home Assistant long-lived access token.</param>
        public ServiceClient(Uri instance, string apiKey) : base(instance, apiKey) { }

        /// <summary>
        /// Retrieves a list of current services, separated into service domains.
        /// </summary>
        /// <returns>A <see cref="List{ServiceDomainObject}" /> representing available services grouped by domain.</returns>
        public async Task<List<ServiceDomainObject>> GetServices() => await Get<List<ServiceDomainObject>>("/api/services");

        /// <summary>
        /// Calls a service using the given <paramref name="domain" />, <paramref name="service" />, and optionally, <paramref name="fields" />.
        /// </summary>
        /// <param name="domain">The domain of the service (e.g. "light").</param>
        /// <param name="service">The name of the service (e.g. "turn_on").</param>
        /// <param name="fields">Optional. An object representing the fields/parameters to pass to the service. Can be an anonymous type, or a <see cref="Dictionary{TKey, TValue}">Dictionary&lt;string, object&gt;</see>.</param>
        /// <returns></returns>
        public async Task<List<StateObject>> CallService(string domain, string service, object fields = null) => await Post<List<StateObject>>($"/api/services/{domain}/{service}", fields);

        /// <summary>
        /// Calls a service using the given fully-qualified <paramref name="serviceName" />, and optionally, <paramref name="fields" />.
        /// </summary>
        /// <param name="serviceName">The fully-qualified service name (e.g. "light.turn_on").</param>
        /// <param name="fields">Optional. An object representing the fields/parameters to pass to the service. Can be an anonymous type, or a <see cref="Dictionary{TKey, TValue}">Dictionary&lt;string, object&gt;</see>.</param>
        /// <returns></returns>
        public async Task<List<StateObject>> CallService(string serviceName, object fields = null) => await Post<List<StateObject>>($"/api/services/{serviceName.Split('.')[0]}/{serviceName.Split('.')[1]}", fields);

        /// <summary>
        /// Calls a service using the given <paramref name="domain" />, <paramref name="service" />, and optionally, <paramref name="fields" />.
        /// </summary>
        /// <param name="domain">The domain of the service (e.g. "light").</param>
        /// <param name="service">The name of the service (e.g. "turn_on").</param>
        /// <param name="fields">Optional. A JSON string representing the fields/parameters to pass to the service. Ensure the JSON is a well-formatted object.</param>
        /// <returns></returns>
        public async Task<List<StateObject>> CallService(string domain, string service, string fields = null) => await Post<List<StateObject>>($"/api/services/{domain}/{service}", fields, true);

        /// <summary>
        /// Calls a service using the given fully-qualified <paramref name="serviceName" />, and optionally, <paramref name="fields" />.
        /// </summary>
        /// <param name="serviceName">The fully-qualified service name (e.g. "light.turn_on").</param>
        /// <param name="fields">Optional. A JSON string representing the fields/parameters to pass to the service. Ensure the JSON is a well-formatted object.</param>
        /// <returns></returns>
        public async Task<List<StateObject>> CallService(string serviceName, string fields = null) => await Post<List<StateObject>>($"/api/services/{serviceName.Split('.')[0]}/{serviceName.Split('.')[1]}", fields, true);

        /// <summary>
        /// Calls a service using the given fully-qualified <paramref name="serviceName" /> and one or more <paramref name="entityIds" />.
        /// </summary>
        /// <param name="serviceName">The fully-qualified service name (e.g. "light.turn_on").</param>
        /// <param name="entityIds">The entity IDs to pass to the service (using the <c>entity_ids</c> parameter).</param>
        /// <returns></returns>
        public async Task<List<StateObject>> CallServiceForEntities(string serviceName, params string[] entityIds) => await Post<List<StateObject>>($"/api/services/{serviceName.Split('.')[0]}/{serviceName.Split('.')[1]}", new { entity_id = entityIds });
    }
}
