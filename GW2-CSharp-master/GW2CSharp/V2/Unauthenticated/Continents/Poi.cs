using GW2CSharp.V2.Unauthenticated.Continents.Enums;
using System.Collections.Generic;

namespace GW2CSharp.V2.Unauthenticated.Continents
{
    /// <summary>
    /// Represents a single poi.
    /// </summary>
    public class Poi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Poi"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        /// <param name="coord">The coord.</param>
        /// <param name="id">The identifier.</param>
        public Poi(string name, PoiType type, List<double> coord, int id)
        {
            Name = name;
            Type = type;
            Coordinate = new Coordinate<double>(coord[0], coord[1]);
            Id = id;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        public PoiType Type { get; private set; }

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
