
namespace GW2CSharp.V2.Unauthenticated.Colors
{
    /// <summary>
    /// Represents a single DyeMaterial.
    /// </summary>
    public class DyeMaterial
    {
        /// <summary>
        /// Initialization of a new DyeMaterial object.
        /// </summary>
        /// <param name="brightness">The brightness.</param>
        /// <param name="contrast">The contrast.</param>
        /// <param name="hue">The hue in the HSL colorspace.</param>
        /// <param name="saturation">The saturation in the HSL colorspace.</param>
        /// <param name="lightness">The lightness in the HSL colorspace.</param>
        /// <param name="rgb">A array containing precalculated RGB values.</param>
        public DyeMaterial(int brightness, decimal contrast, int hue, decimal saturation, decimal lightness, int[] rgb)
        {
            Brightness = brightness;
            Contrast = contrast;
            Hue = hue;
            Saturation = saturation;
            Lightness = lightness;
            RGB = rgb;
        }

        /// <summary>
        /// The brightness.
        /// </summary>
        public int Brightness { get; private set; }

        /// <summary>
        /// The contrast.
        /// </summary>
        public decimal Contrast { get; private set; }

        /// <summary>
        /// The hue in the HSL colorspace.
        /// </summary>
        public int Hue{ get; private set; }

        /// <summary>
        /// The saturation in the HSL colorspace.
        /// </summary>
        public decimal Saturation { get; private set; }

        /// <summary>
        /// The lightness in the HSL colorspace.
        /// </summary>
        public decimal Lightness { get; private set; }

        /// <summary>
        /// A array containing precalculated RGB values.
        /// </summary>
        public int[] RGB { get; private set; }
    }
}
