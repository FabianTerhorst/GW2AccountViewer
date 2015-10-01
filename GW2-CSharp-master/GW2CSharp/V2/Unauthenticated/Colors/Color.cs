using Newtonsoft.Json;

namespace GW2CSharp.V2.Unauthenticated.Colors
{
    /// <summary>
    /// Represents a single color of the v2/colors endpoint.
    /// </summary>
    public class Color
    {
        /// <summary>
        /// Initialization of a new color object.
        /// </summary>
        /// <param name="id">The color id.</param>
        /// <param name="name">The color name.</param>
        /// <param name="baseRgb">The base RGB values.</param>
        /// <param name="cloth">Detailed information on its appearance when applied on cloth armor.</param>
        /// <param name="leather">Detailed information on its appearance when applied on leather armor.</param>
        /// <param name="metal">Detailed information on its appearance when applied on metal armor.</param>
        public Color(int id, string name, int[] baseRgb, DyeMaterial cloth, DyeMaterial leather, DyeMaterial metal)
        {
            Id = id;
            Name = name;
            BaseRGB = baseRgb;
            Cloth = cloth;
            Leather = leather;
            Metal = metal;
        }

        /// <summary>
        /// The color id.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// The color name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The base RGB values.
        /// </summary>
        [JsonProperty(PropertyName = "base_rgb")]
        public int[] BaseRGB { get; private set; }

        /// <summary>
        /// Detailed information on its appearance when applied on cloth armor.
        /// </summary>
        public DyeMaterial Cloth { get; private set; }

        /// <summary>
        /// Detailed information on its appearance when applied on leather armor.
        /// </summary>
        public DyeMaterial Leather { get; private set; }

        /// <summary>
        /// Detailed information on its appearance when applied on metal armor.
        /// </summary>
        public DyeMaterial Metal { get; private set; }
    }
}
