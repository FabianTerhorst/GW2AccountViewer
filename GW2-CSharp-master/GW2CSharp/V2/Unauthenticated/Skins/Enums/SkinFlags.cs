
namespace GW2CSharp.V2.Unauthenticated.Items.Skins.Enums
{
    /// <summary>
    /// Additional skin flags.
    /// </summary>
    public enum SkinFlag
    {
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined,
        /// <summary>
        /// When displayed in the account wardrobe (set for all skins listed in the API)
        /// </summary>
        ShowInWardrobe,
        /// <summary>
        /// When applying the skin is free.
        /// </summary>
        NoCost,
        /// <summary>
        ///  When the skin is hidden until it is unlocked.
        /// </summary>
        HideIfLocked
    }
}
