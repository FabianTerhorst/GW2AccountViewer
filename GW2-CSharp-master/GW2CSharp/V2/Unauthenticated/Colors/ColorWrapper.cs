using GW2CSharp.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GW2CSharp.V2.Unauthenticated.Colors
{
    /// <summary>
    /// Represents a wrapper for the v2/colors endpoint.
    /// </summary>
    public class ColorWrapper : ApiBase
    {
        /// <summary>
        /// Returns the color that matches the id.
        /// </summary>
        /// <param name="id">The color id.</param>
        /// <param name="requestedLanguage">Represents the language which the API should return. Default english.</param>
        /// <returns>Color that matches the id.</returns>
        public Color GetColorById(int id, RequestedLanguage requestedLanguage = RequestedLanguage.En)
        {
            string jsonString = DownloadJsonString(string.Format("https://api.guildwars2.com/v2/colors/{0}?lang={1}", id, requestedLanguage));
            return JsonConvert.DeserializeObject<Color>(jsonString);
        }

        /// <summary>
        /// Returns the a Dictionary with all known colors.
        /// </summary>
        /// <param name="requestedLanguage">Represents the language which the API should return. Default english.</param>
        /// <returns>Dictionary with all known colors.</returns>
        public Dictionary<int, Lazy<Color>> GetAllColors(RequestedLanguage requestedLanguage = RequestedLanguage.En)
        {
            string jsonString = DownloadJsonString(string.Format("https://api.guildwars2.com/v2/colors"));

            List<int> colorIds = JsonConvert.DeserializeObject<List<int>>(jsonString);

            var colors = new Dictionary<int, Lazy<Color>>();
            foreach (var colorId in colorIds)
            {
                colors.Add(colorId, new Lazy<Color>(() => GetColorById(colorId, requestedLanguage)));
            }
            return colors;
        }

        /// <summary>
        /// Returns colors in pagesize.
        /// </summary>
        /// <param name="page">Page number.</param>
        /// <param name="pageSize">Size of colors on one page.</param>
        /// <param name="requestedLanguage">Represents the language which the API should return. Default english.</param>
        /// <returns>Color object on the given page.</returns>
        public IEnumerable<Color> GetColorByPage(int page, int pageSize, RequestedLanguage requestedLanguage = RequestedLanguage.En)
        {
            string jsonString = DownloadJsonString(string.Format("https://api.guildwars2.com/v2/colors?page={0}&page_size={1}&lang={2}", page, pageSize, requestedLanguage));
            return JsonConvert.DeserializeObject<IEnumerable<Color>>(jsonString);
        }
    }
}
