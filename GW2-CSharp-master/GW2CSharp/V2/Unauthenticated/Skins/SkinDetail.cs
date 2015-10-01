using GW2CSharp.Enums;
using Newtonsoft.Json;
using System;

namespace GW2CSharp.V2.Unauthenticated.Items.Skins
{
    /// <summary>
    /// Represents additional Skin details.
    /// </summary>
    public class SkinDetail
    {
        /// <summary>
        /// Initilization of a new skindetail object.
        /// </summary>
        /// <param name="type">Skin type.</param>
        /// <param name="weight_class">The armor weight.</param>
        /// <param name="damage_type">The damage type.</param>
        public SkinDetail(string type, string weight_class, string damage_type)
	    {
            Armor armorResult = Armor.Undefined;
            if (Enum.TryParse<Armor>(type, out armorResult))
            {
                Armor = armorResult;
            }

            Weapon weaponResult = Weapon.Undefined;
            if (Enum.TryParse<Weapon>(type, out weaponResult))
            {
                Weapon = weaponResult;
            }

            Weight weightResult = Weight.Undefined;
            if (Enum.TryParse<Weight>(weight_class, out weightResult))
            {
                Weight = weightResult;
            }

            DamageType damageTypeResult = DamageType.Undefined;
            if (Enum.TryParse<DamageType>(damage_type, out damageTypeResult))
            {
                DamageType = damageTypeResult;
            }
	    }

        /// <summary>
        /// The armor type (slot).
        /// </summary>
        public Armor Armor { get; private set; }

        /// <summary>
        ///  The weapon type.
        /// </summary>
        public Weapon Weapon { get; private set; }

        /// <summary>
        /// The armor weight.
        /// </summary>
        public Weight Weight { get; private set; }

        /// <summary>
        /// The damage type.
        /// </summary>
        public DamageType DamageType { get; private set; }
    }
}
