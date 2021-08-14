using System;
using System.Net.Http;
using System.Threading.Tasks;
using HADotNet.Core.Models;

namespace HADotNet.Core.Clients
{
    /// <summary>
    /// Provides access to the camera proxy API which allows fetching of the current image from a camera entity.
    /// </summary>
    public sealed class CameraProxyClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CameraProxyClient" />.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient" /> preconfigured to communicate with a Home Assistant instance.</param>
        public CameraProxyClient(HttpClient client) : base(client) { }

        /// <summary>
        /// Retrieves the most recently available (still) image data from the specified <paramref name="cameraEntityId" />.
        /// </summary>
        /// <param name="cameraEntityId">The camera entity ID to reteive the image for.</param>
        /// <returns>A byte array containing the still image, typically in JPEG format.</returns>
        public async Task<byte[]> GetCameraImage(string cameraEntityId) => await Get<byte[]>($"/api/camera_proxy/{cameraEntityId}");

        /// <summary>
        /// Retrieves the most recently available (still) image data from the specified <paramref name="cameraEntityId" />.
        /// </summary>
        /// <param name="cameraEntityId">The camera entity ID to reteive the image for.</param>
        /// <param name="includeDataPrefix"><c>true</c> to include the prefix "data:image/jpg;base64,", <c>false</c> to omit. Defaults to <c>true</c>.</param>
        /// <returns>A web-friendly Base64-encoded still image, in JPEG format.</returns>
        public async Task<string> GetCameraImageAsBase64(string cameraEntityId, bool includeDataPrefix = true) => (includeDataPrefix ? "data:image/jpg;base64," : "") + Convert.ToBase64String(await Get<byte[]>($"/api/camera_proxy/{cameraEntityId}"));
    }
}
