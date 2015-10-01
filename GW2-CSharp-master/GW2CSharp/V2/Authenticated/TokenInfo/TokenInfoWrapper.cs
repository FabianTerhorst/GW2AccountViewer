using Newtonsoft.Json;

namespace GW2CSharp.V2.Authenticated.TokenInfo
{
    /// <summary>
    /// Represents a wrapper for the v2/tokeninfo endpoint.
    /// </summary>
    public class TokeninfoWrapper : ApiBase
    {
        /// <summary>
        /// This resource returns information about the supplied API key. 
        /// </summary>
        /// <param name="token">API key.</param>
        /// <returns>Informations about the supplied API key.</returns>
        public Tokeninfo GetTokeninfo(string token) 
        {
            string jsonString = DownloadJsonString("https://api.guildwars2.com/v2/tokeninfo?access_token=" + token);
            return JsonConvert.DeserializeObject<Tokeninfo>(jsonString);
        }
    }
}
