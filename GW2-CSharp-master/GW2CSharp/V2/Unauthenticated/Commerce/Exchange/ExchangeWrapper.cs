using GW2CSharp.Entities;

namespace GW2CSharp.V2.Unauthenticated.Commerce.Exchange
{
    /// <summary>
    /// Represents a wrapper for the v2/commerce/exchange endpoint.
    /// </summary>
    public class ExchangeWrapper : ApiBase
    {
        /// <summary>
        /// Returns a specific amount of coins.
        /// </summary>
        /// <param name="money">The amount of coins to exchange for gems.</param>
        /// <returns>Coin object.</returns>
        public Coin GetCoin(Money money) 
        {
            return DeserializeObject<Coin>("https://api.guildwars2.com/v2/commerce/exchange/coins?quantity=" + money.GetRawCoin());
        }

        /// <summary>
        /// Returns a specific amount of gems.
        /// </summary>
        /// <param name="amountOfGems">The amount of gems to exchange for coins.</param>
        /// <returns>Gem object.</returns>
        public Gem GetGem(int amountOfGems)
        {
            return DeserializeObject<Gem>("https://api.guildwars2.com/v2/commerce/exchange/gems?quantity=" + amountOfGems);
        }
    }
}
