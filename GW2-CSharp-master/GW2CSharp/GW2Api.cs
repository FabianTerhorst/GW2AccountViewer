using GW2CSharp.Services;
using GW2CSharp.V1;
using GW2CSharp.V2;
using GW2CSharp.V2.Unauthenticated.Miscellaneous;
using GW2CSharp.V2.Unauthenticated.Colors;
using GW2CSharp.V2.Unauthenticated.Currencies;
using GW2CSharp.V2.Unauthenticated.Worlds;

namespace GW2CSharp
{
    /// <summary>
    /// Represents the Guild Wars 2 Api.
    /// <para>All calls will throw a <see cref="ApiException"/> if an error occurs.</para>
    /// <para>
    /// Full documentation under: http://gw2dotnettools.github.io/GW2-CSharp-Documentation
    /// </para>
    /// </summary>
    public static class GW2Api
    {
        /// <summary>
        /// Returns the V1 endpoint.
        /// </summary>
        public static V1Endpoint V1
        {
            get
            {
                return new V1Endpoint();
            }
        }

        /// <summary>
        /// Returns the V2 endpoint.
        /// </summary>
        public static V2Endpoint V2 
        {
            get
            {
                return new V2Endpoint(); 
            } 
        }
    }
}
