using GW2CSharp.Services;
using System.Drawing;

namespace GW2CSharp.V2.Unauthenticated.Currencies
{
    /// <summary>
    /// Represents a single currency of the v2/currencies endpoint.
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// Initialization of a new currency object.
        /// </summary>
        /// <param name="id">The currency's ID.</param>
        /// <param name="name">The currency's name.</param>
        /// <param name="description">A description of the currency.</param>
        /// <param name="order">A number that can be used to sort the list of currencies when ordered from least to greatest.</param>
        /// <param name="icon">A URL to an icon for the currency.</param>
        public Currency(int id, string name, string description, int order, string icon)
        {
            Id = id;
            Name = name;
            Description = description;
            Order = order;
            Icon = icon;
        }

        /// <summary>
        /// The currency's ID.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// The currency's name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// A description of the currency.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// A number that can be used to sort the list of currencies when ordered from least to greatest.
        /// </summary>
        public int Order { get; private set; }

        /// <summary>
        /// A URL to an icon for the currency.
        /// </summary>
        public string Icon { get; private set; }

        /// <summary>
        /// Returns the Icon as a Bitmap.
        /// </summary>
        /// <returns>Icon as a Bitmap.</returns>
        public Bitmap GetImage() 
        {
            return RenderService.GetImage(Icon);
        }
    }
}
