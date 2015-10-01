using System.Collections.Generic;

namespace GW2CSharp.V2.Unauthenticated.Continents
{
    /// <summary>
    /// Represents a single SkillChallenge.
    /// </summary>
    public class SkillChallenge
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SkillChallenge"/> class.
        /// </summary>
        /// <param name="coord">The coord.</param>
        public SkillChallenge(List<double> coord)
        {
            Coordinate = new Coordinate<double>(coord[0], coord[1]);
        }

        /// <summary>
        /// Gets the coordinate.
        /// </summary>
        public Coordinate<double> Coordinate { get; private set; }
    }
}
