using System;
using System.Collections.Generic;

namespace GW2CSharp.V2.Unauthenticated.Continents
{
    /// <summary>
    /// Represents a floor.
    /// </summary>
    public class Floor : ApiBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Floor"/> class.
        /// </summary>
        /// <param name="texture_dims">The dimension.</param>
        /// <param name="regions">The regions.</param>
        public Floor(List<int> texture_dims, Dictionary<string, Lazy<Region>> regions)
        {
            Dimension = new Coordinate<int>(texture_dims[0], texture_dims[1]);
            Regions = regions;
        }

        /// <summary>
        /// Gets the dimension.
        /// </summary>
        public Coordinate<int> Dimension { get; private set; }

        /// <summary>
        /// Gets the regions.
        /// </summary>
        public Dictionary<string, Lazy<Region>> Regions { get; private set; }
    }
}
