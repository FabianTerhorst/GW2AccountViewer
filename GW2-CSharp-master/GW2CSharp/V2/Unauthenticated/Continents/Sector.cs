using System.Collections.Generic;

namespace GW2CSharp.V2.Unauthenticated.Continents
{
    /// <summary>
    /// Represents a single Sector.
    /// </summary>
    public class Sector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sector"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="level">The level.</param>
        /// <param name="coord">The coord.</param>
        public Sector(int id, string name, int level, List<double> coord)
        {
            Id = id;
            Name = name;
            Level = level;
            Coordinate = new Coordinate<double>(coord[0], coord[1]);
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the level.
        /// </summary>
        public int Level { get; private set; }

        /// <summary>
        /// Gets the coordinate.
        /// </summary>
        public Coordinate<double> Coordinate { get; private set; }
    }
}
