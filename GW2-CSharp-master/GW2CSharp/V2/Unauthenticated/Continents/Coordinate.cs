
namespace GW2CSharp.V2.Unauthenticated.Continents
{
    /// <summary>
    /// Represents a Coordinate.
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class Coordinate<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinate{T}"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public Coordinate(T x, T y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets the x.
        /// </summary>
        public T X { get; private set; }

        /// <summary>
        /// Gets the y.
        /// </summary>
        public T Y { get; private set; }
    }
}
