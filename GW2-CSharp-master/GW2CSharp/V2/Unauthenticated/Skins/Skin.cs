using GW2CSharp.Enums;
using GW2CSharp.Services;
using GW2CSharp.V2.Unauthenticated.Items.Skins.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2CSharp.V2.Unauthenticated.Items.Skins
{
    /// <summary>
    /// Represents a single object of the v2/skins endpoint
    /// </summary>
    public class Skin
    {
        /// <summary>
        /// Represents a single skin.
        /// </summary>
        /// <param name="id">The skin id.</param>
        /// <param name="name">The name of the skin.</param>
        /// <param name="type">The skin type.</param>
        /// <param name="flags">Additional skin flags.</param>
        /// <param name="restrictions">Restrictions that apply to the skin.</param>
        /// <param name="icon">The full icon URL.</param>
        /// <param name="description">Optional skin description.</param>
        /// <param name="details">Additional skin details.</param>
        public Skin(int id, string name, SkinType type, IEnumerable<SkinFlag> flags, IEnumerable<Restriction> restrictions, string icon, string description, SkinDetail details)
        {
            Id = id;
            Name = name;
            Type = type;
            Flags = flags;
            Restrictions = restrictions;
            Icon = icon;
            Description = description;
            Details = details;
        }

        /// <summary>
        /// The skin id.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// The name of the skin.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The skin type.
        /// </summary>
        public SkinType Type { get; private set; }

        /// <summary>
        /// Additional skin flags.
        /// </summary>
        public IEnumerable<SkinFlag> Flags { get; private set; }

        /// <summary>
        /// Restrictions that apply to the skin.
        /// </summary>
        public IEnumerable<Restriction> Restrictions { get; private set; }

        /// <summary>
        /// The full icon URL.
        /// </summary>
        public string Icon { get; private set; }

        /// <summary>
        /// Optional skin description. Might contain c=@flavor
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Additional skin details.
        /// </summary>
        public SkinDetail Details { get; private set; }

        /// <summary>
        /// Returns the Icon from the Url.
        /// </summary>
        /// <returns>Icon from the Url.</returns>
        public Bitmap GetIcon() 
        {
            return RenderService.GetImage(Icon);
        }
    }
}
