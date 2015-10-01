using GW2CSharp.Entities;
using Newtonsoft.Json;

namespace GW2CSharp.V2.Unauthenticated.Commerce.Exchange
{
    /// <summary>
    /// Represents a exchange gem of the v2/commerce/exchange/gem endpoint.
    /// </summary>
    public class Gem
    {
        /// <summary>
        ///  The number of coins you get for a single gem as a calculated value.
        /// </summary>
        public Money CoinsPerGemCalculated { get { return new Money(CoinsPerGemRaw); } }

        /// <summary>
        /// The number of coins you get for the specified quantity of gems as a calculated value.
        /// </summary>
        public Money AmountOfCoinsCalculated { get { return new Money(AmountOfCoinsRaw); } }

        /// <summary>
        ///  The number of coins you get for a single gem.
        /// </summary>
        [JsonProperty(PropertyName = "coins_per_gem")]
        public int CoinsPerGemRaw { get; private set; }

        /// <summary>
        /// The number of coins you get for the specified quantity of gems.
        /// </summary>
        [JsonProperty(PropertyName = "quantity")]
        public int AmountOfCoinsRaw { get; private set; }
    }
}
