using System.Collections.Generic;

namespace GW2CSharp.V2.Unauthenticated.Continents
{
    /// <summary>
    /// Represents a single Rectangle.
    /// </summary>
    public class Rectangle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public Rectangle(List<int> x, List<int> y)
        {
            X = new Coordinate<int>(x[0], x[1]);
            Y = new Coordinate<int>(y[0], y[1]);
        }

        /// <summary>
        /// Gets the x.
        /// </summary>
        public Coordinate<int> X { get; private set; }

        /// <summary>
        /// Gets the y.
        /// </summary>
        public Coordinate<int> Y { get; private set; }
    }
}
