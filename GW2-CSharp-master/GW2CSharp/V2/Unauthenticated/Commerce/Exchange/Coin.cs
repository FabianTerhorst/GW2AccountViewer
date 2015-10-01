using GW2CSharp.Entities;
using Newtonsoft.Json;

namespace GW2CSharp.V2.Unauthenticated.Commerce.Exchange
{
    /// <summary>
    /// Represents a exchange coin of the v2/commerce/exchange/coins endpoint.
    /// </summary>
    public class Coin
    {
        /// <summary>
        ///  The number of coins you require for a single gem as a calculated value.
        /// </summary>
        public Money CoinsPerGemCalculated { get { return new Money(CoinsPerGemRaw); } }

        /// <summary>
        /// The number of gems you get for the specified quantity of coins.
        /// </summary>
        [JsonProperty(PropertyName = "quantity")]
        public int AmountOfGems { get; private set; }

        /// <summary>
        ///  The number of coins you require for a single gem.
        /// </summary>
        [JsonProperty(PropertyName = "coins_per_gem")]
        public int CoinsPerGemRaw { get; set; }
    }
}
