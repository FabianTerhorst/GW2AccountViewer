using GW2CSharp.Services;
using System.Drawing;

namespace GW2CSharp.V2.Unauthenticated.Files
{
    /// <summary>
    /// Represents a single file of the v2/files endpoint.
    /// </summary>
    public class RessourceFile
    {
        /// <summary>
        /// Initialization of a new color object.
        /// </summary>
        /// <param name="id">The file identifier.</param>
        /// <param name="icon">The URL to the image.</param>
        public RessourceFile(string id, string icon)
        {
            Id = id;
            Icon = icon;
        }

        /// <summary>
        /// The file identifier.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// The URL to the image.
        /// </summary>
        public string Icon { get; private set; }

        /// <summary>
        /// Returns a file image as a Bitmap.
        /// </summary>
        /// <returns>File image as a Bitmap.</returns>
        public Bitmap GetImage() 
        {
            return RenderService.GetImage(Icon);
        }
    }
}
