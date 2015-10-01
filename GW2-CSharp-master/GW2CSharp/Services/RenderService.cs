using GW2CSharp.Services.Enums;
using System;
using System.Drawing;
using System.Net;

namespace GW2CSharp.Services
{
    /// <summary>
    /// Represents the render service which provides access to in-game assets like item icons.
    /// </summary>
    public static class RenderService
    {
        private const string Pattern = "https://render.guildwars2.com/file/{0}/{1}.{2}";

        /// <summary>
        /// Returns a Bitmap from the render service.
        /// </summary>
        /// <param name="signature">Signature of the image.</param>
        /// <param name="fileId">FileId of the image.</param>
        /// <param name="format">Format of the image.</param>
        /// <returns>Bitmap from the render service.</returns>
        public static Bitmap GetImage(string signature, string fileId, FileFormat format)
        {
            string url = string.Format(Pattern, signature, fileId, format.ToString());

            return GetImage(url);
        }

        /// <summary>
        /// Returns a Bitmap from the render service.
        /// </summary>
        /// <param name="url">Link to the image.</param>
        /// <returns>Bitmap from the render service.</returns>
        public static Bitmap GetImage(string url)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.Method = "GET";

            Bitmap bmp = null;
            try
            {
                using (HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse())
                {
                    bmp = new Bitmap(myResponse.GetResponseStream());
                }
            }
            catch (Exception)
            {
                throw new ArgumentException(url + " does not return a valid object.");
            }

            return bmp;
        }
    }
}
