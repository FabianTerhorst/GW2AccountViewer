using GW2CSharp.Services;
using System.Drawing;

namespace GW2CSharp.V2.Unauthenticated.Quaggans
{
    /// <summary>
    /// Represents a single quaggan from the v2/quaggans endpoint.
    /// </summary>
    public class Quaggan
    {
        /// <summary>
        /// Initialization of a new quaggan object.
        /// </summary>
        /// <param name="id">The quaggan identifier.</param>
        /// <param name="url">The URL to the quaggan image.</param>
        public Quaggan(string id, string url)
        {
            Id = id;
            Url = url;
        }

        /// <summary>
        /// The quaggan identifier.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// The URL to the quaggan image.
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// Returns a quaggan image as a Bitmap.
        /// </summary>
        /// <returns>Quaggan image as a Bitmap.</returns>
        public Bitmap GetImage() 
        {
            return RenderService.GetImage(Url);
        }
    }
}
