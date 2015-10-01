
namespace GW2CSharp.V2.Authenticated.Pvp.Stats
{
    /// <summary>
    /// Represents a statistic given by the v2/pvp/stats endpoint.
    /// </summary>
    public class Statistic
    {
        /// <summary>
        /// Initilatizion of a new statistic object.
        /// </summary>
        /// <param name="wins">The wins for the category.</param>
        /// <param name="losses">The losses for the category.</param>
        /// <param name="desertions">The desertions for the category.</param>
        /// <param name="byes">The byes for the category.</param>
        /// <param name="forfeits">The forfeit for the category.</param>
        public Statistic(int wins, int losses, int desertions, int byes, int forfeits) 
        {
            Wins = wins;
            Losses = losses;
            Desertions = desertions;
            Byes = byes;
            Forfeits = forfeits;
        }

        /// <summary>
        /// The wins for the category.
        /// </summary>
        public int Wins { get; private set; }

        /// <summary>
        /// The losses for the category.
        /// </summary>
        public int Losses { get; private set; }

        /// <summary>
        /// The desertions for the category.
        /// </summary>
        public int Desertions { get; private set; }

        /// <summary>
        /// The byes for the category.
        /// </summary>
        public int Byes { get; private set; }

        /// <summary>
        /// The forfeit for the category.
        /// </summary>
        public int Forfeits { get; private set; }
    }
}
