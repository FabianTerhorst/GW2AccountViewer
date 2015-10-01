using System.Collections.Generic;

namespace GW2CSharp.V2.Unauthenticated.Continents
{
    /// <summary>
    /// Represents a single objective.
    /// </summary>
    public class Objective
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Objective"/> class.
        /// </summary>
        /// <param name="objective">The objective.</param>
        /// <param name="level">The level.</param>
        /// <param name="coord">The coord.</param>
        /// <param name="id">The identifier.</param>
        public Objective(string objective, int level, List<double> coord, int id)
        {
            Text = objective;
            Level = level;
            Coordinate = new Coordinate<double>(coord[0], coord[1]);
            Id = id;
        }

        /// <summary>
        /// Gets the text.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Gets the level.
        /// </summary>
        public int Level { get; private set; }

        /// <summary>
        /// Gets the coordinate.
        /// </summary>
        public Coordinate<double> Coordinate { get; private set; }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public int Id { get; private set; }
    }
}
