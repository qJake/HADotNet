using System;

namespace HADotNet.Core.Domain
{
    /// <summary>
    /// Represents a failed HTTP call to a Home Assistant endpoint.
    /// </summary>
    public class HttpResponseException : Exception
    {
        /// <summary>
        /// Gets the status code for the HTTP response.
        /// </summary>
        public int StatusCode { get; }

        /// <summary>
        /// Gets the network description, if the error was at the network level.
        /// </summary>
        public string NetworkDescription { get; }

        /// <summary>
        /// Gets the original request path.
        /// </summary>
        public string RequestPath { get; }

        /// <summary>
        /// Gets the error response body.
        /// </summary>
        public string ResponseBody { get; }

        /// <summary>
        /// Initializes a new HttpResponseException.
        /// </summary>
        public HttpResponseException(int statusCode, string networkDescription, string requestPath, string responseBody)
        {
            StatusCode = statusCode;
            NetworkDescription = networkDescription;
            RequestPath = requestPath;
            ResponseBody = responseBody;
        }

        /// <summary>
        /// Initializes a new HttpResponseException.
        /// </summary>
        public HttpResponseException(int statusCode, string networkDescription, string requestPath, string responseBody, string message) : base(message)
        {
            StatusCode = statusCode;
            NetworkDescription = networkDescription;
            RequestPath = requestPath;
            ResponseBody = responseBody;
        }

        /// <summary>
        /// Initializes a new HttpResponseException.
        /// </summary>
        public HttpResponseException(int statusCode, string networkDescription, string requestPath, string responseBody, string message, Exception innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
            NetworkDescription = networkDescription;
            RequestPath = requestPath;
            ResponseBody = responseBody;
        }
    }
}
