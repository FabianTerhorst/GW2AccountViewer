using GW2CSharp.Enums;
using GW2CSharp.V2.Authenticated.Pvp.Stats.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GW2CSharp.V2.Authenticated.Pvp.Stats
{
    /// <summary>
    /// Represents the v2/pvp/stats endpoint.
    /// </summary>
    public class PvpStatistic
    {
        /// <summary>
        /// Initilization of a new pvpstatistic object.
        /// </summary>
        /// <param name="rank">The player's PvP rank.</param>
        /// <param name="overview">A win/loss object containing stats from all matches ever played.</param>
        /// <param name="professions">Collection for each profession played in PvP.</param>
        /// <param name="ladders">Collection for each type of the ladder.</param>
        public PvpStatistic(int rank, Statistic overview, Dictionary<Profession, Statistic> professions, Dictionary<Ladder, Statistic> ladders)
        {
            Rank = rank;
            Overview = overview;
            Professions = professions;
            Ladders = ladders;
        }

        /// <summary>
        /// The player's PvP rank.
        /// </summary>
        [JsonProperty(PropertyName = "pvp_rank")]
        public int Rank { get; private set; }

        /// <summary>
        /// A win/loss object containing stats from all matches ever played.
        /// </summary>
        [JsonProperty(PropertyName = "aggregate")]
        public Statistic Overview { get; private set; }

        /// <summary>
        /// Collection for each profession played in PvP.
        /// </summary>
        public Dictionary<Profession, Statistic> Professions { get; private set; } 

        /// <summary>
        /// Collection for each type of the ladder.
        /// </summary>
        public Dictionary<Ladder, Statistic> Ladders { get; private set; }
    }
}
