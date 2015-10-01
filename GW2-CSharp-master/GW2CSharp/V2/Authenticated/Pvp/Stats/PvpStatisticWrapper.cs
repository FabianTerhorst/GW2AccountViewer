using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2CSharp.V2.Authenticated.Pvp.Stats
{
    /// <summary>
    /// Represents a wrapper for the v2/pvp/stats endpoint.
    /// </summary>
    public class PvpStatisticWrapper : ApiBase
    {
        /// <summary>
        /// Returns PvpStatistics about the given account.
        /// </summary>
        /// <param name="token">API key.</param>
        /// <returns>PvpStatistics about the account.</returns>
        public PvpStatistic GetPvpStatistic(string token)
        {
            string jsonString = DownloadJsonString("https://api.guildwars2.com/v2/pvp/stats?access_token=" + token);
            return JsonConvert.DeserializeObject<PvpStatistic>(jsonString);
        }
    }
}
