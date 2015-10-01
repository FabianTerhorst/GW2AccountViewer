using Newtonsoft.Json;
using System.Collections.Generic;

namespace GW2CSharp.V2.Unauthenticated.Files
{
    /// <summary>
    /// Represents a wrapper for the v2/quaggans endpoint.
    /// </summary>
    public class RessourceFileWrapper : ApiBase
    {
        /// <summary>
        /// Returns a single RessourceFile that matches the id.
        /// </summary>
        /// <param name="id">The file identifier.</param>
        /// <returns>RessourceFile that matches the id.</returns>
        public RessourceFile GetRessourceFile(string id) 
        {
            string jsonString = DownloadJsonString(string.Format("https://api.guildwars2.com/v2/files?id={0}", id));
            return JsonConvert.DeserializeObject<RessourceFile>(jsonString);
        }

        /// <summary>
        /// Returns all RessourceFiles that matches the id.
        /// </summary>
        /// <param name="ids">The file identifier.</param>
        /// <returns>RessourceFiles that matches the id.</returns>
        public IEnumerable<RessourceFile> GetMultipleRessourceFiles(params string[] ids)
        {
            return GetMultipleRessourceFiles(new List<string>(ids));
        }

        /// <summary>
        /// Returns all RessourceFiles that matches the id.
        /// </summary>
        /// <param name="ids">The file identifiers.</param>
        /// <returns>RessourceFiles that matches the id.</returns>
        public IEnumerable<RessourceFile> GetMultipleRessourceFiles(IEnumerable<string> ids)
        {
            string url = "https://api.guildwars2.com/v2/files?ids=";
            foreach (var id in ids)
            {
                url += id + ",";
            }

            string jsonString = DownloadJsonString(url);
            return JsonConvert.DeserializeObject<IEnumerable<RessourceFile>>(jsonString);
        }

        /// <summary>
        /// Returns all RessourceFiles.
        /// </summary>
        /// <returns>All RessourceFiles.</returns>
        public IEnumerable<RessourceFile> GetAllRessourceFiles()
        {
            string jsonString = DownloadJsonString("https://api.guildwars2.com/v2/files?ids=all");
            return JsonConvert.DeserializeObject<IEnumerable<RessourceFile>>(jsonString);
        }
    }
}
