using System.Collections.Generic;

namespace GW2CSharp.V2.Authenticated.TokenInfo
{
    /// <summary>
    /// Represents the permissions of an account.
    /// </summary>
    public class Permission
    {
        internal Permission(List<string> permissions)
        {
            Wallet = permissions.Contains("wallet");
            Tradingpost = permissions.Contains("tradingpost");
            Builds = permissions.Contains("builds");
            Account = permissions.Contains("account");
            Inventories = permissions.Contains("inventories");
            Characters = permissions.Contains("characters");
            Unlocks = permissions.Contains("unlocks");
            Pvp = permissions.Contains("pvp");
        }
        
        /// <summary>
        /// Grants access to the /v2/wallet endpoint.
        /// </summary>
        public bool Wallet { get; private set; }

        /// <summary>
        /// Grants access to the /v2/commerce/transactions endpoint.
        /// </summary>
        public bool Tradingpost { get; private set; }

        /// <summary>
        ///  Grants access to view each character's equipped specializations.
        /// </summary>
        public bool Builds { get; private set; }

        /// <summary>
        /// Grants access to the /v2/account endpoint (This permission is required for all API keys).
        /// </summary>
        public bool Account { get; private set; }

        /// <summary>
        /// Grants access to inventories in the /v2/characters endpoint and to the /v2/account/bank endpoint.
        /// </summary>
        public bool Inventories { get; private set; }

        /// <summary>
        /// Grants access to the /v2/characters endpoint.
        /// </summary>
        public bool Characters { get; private set; }

        /// <summary>
        /// Grants access to the /v2/skins and /v2/dyes endpoints.
        /// </summary>
        public bool Unlocks { get; private set; }

        /// <summary>
        /// Grants access to the /v2/pvp sub-endpoints. (i.e. /v2/pvp/games, /v2/pvp/stats)
        /// </summary>
        public bool Pvp { get; private set; }
    }
}
