using Newtonsoft.Json;
using System;

namespace GW2CSharp.Entities
{
    /// <summary>
    /// Represents money in GW2.
    /// </summary>
    public class Money
    {
        /// <summary>
        /// Initialization of a new money object. All values will be verified.
        /// </summary>
        /// <param name="rawValue">RawValue which is used by the API.</param>
        public Money(int rawValue)
        {
            rawValue = Math.Abs(rawValue);

            Copper = rawValue < 100 ? rawValue : rawValue % 100;
            Silver = rawValue < 10000 ? rawValue / 100 : (rawValue % 10000) / 100;
            Gold = rawValue / 10000;
        }

        /// <summary>
        /// Initialization of a new money object. Expects real values not raw ones.
        /// </summary>
        /// <param name="copper">Copper, value.</param>
        /// <param name="silver">Silver value.</param>
        /// <param name="gold">Gold value.</param>
        public Money(int copper, int silver, int gold)
        {
            Copper = Math.Abs(copper);
            Silver = Math.Abs(silver);
            Gold = Math.Abs(gold);
        }

        /// <summary>
        /// A copper Unit.
        /// </summary>
        public int Copper { get; private set; }

        /// <summary>
        /// A silver Unit.
        /// </summary>
        public int Silver { get; private set; }

        /// <summary>
        /// A gold Unit.
        /// </summary>
        public int Gold { get; private set; }

        /// <summary>
        /// Returns the raw value of this money object.
        /// </summary>
        /// <returns>Raw coin which is used by the API.</returns>
        public int GetRawCoin() 
        {
            int goldInCopper = Gold * 10000;
            int silverInCopper = Silver * 100;

            return Copper + silverInCopper + goldInCopper;
        }
    }
}
