using GW2CSharp.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GW2CSharp.V2.Unauthenticated.Items.Skins
{
    /// <summary>
    /// Represents the v2/skins endpoint
    /// </summary>
    public class SkinWrapper : ApiBase
    {
        /// <summary>
        /// Returns the skin that matches with the id.
        /// </summary>
        /// <param name="id">The skin id.</param>
        /// <param name="requestedLanguage">(Optional) Request localized information.</param>
        /// <returns>Skin that matches with the id.</returns>
        public Skin GetSkinById(int id, RequestedLanguage requestedLanguage = RequestedLanguage.En) 
        {
            string jsonString = DownloadJsonString(string.Format("https://api.guildwars2.com/v2/skins/{0}?lang={1}", id, requestedLanguage));
            return JsonConvert.DeserializeObject<Skin>(jsonString);
        }

        /// <summary>
        /// Returns all known skins.
        /// </summary>
        /// <param name="requestedLanguage">(Optional) Request localized information.</param>
        /// <returns>All known skins.</returns>
        public Dictionary<int, Lazy<Skin>> GetAllSkins(RequestedLanguage requestedLanguage = RequestedLanguage.En)
        {
            string jsonString = DownloadJsonString(string.Format("https://api.guildwars2.com/v2/skins"));

            List<int> skinIds = JsonConvert.DeserializeObject<List<int>>(jsonString);

            var skins = new Dictionary<int, Lazy<Skin>>();
            foreach (var skinId in skinIds)
            {
                skins.Add(skinId, new Lazy<Skin>(() => GetSkinById(skinId, requestedLanguage)));
            }

            return skins;
        }
    }
}
