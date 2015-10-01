using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW2CSharp.V2.Unauthenticated.Worlds.Enums
{
    /// <summary>
    /// Represents the world population level. One of: Low, Medium, High, VeryHigh, Full
    /// </summary>
    public enum Population
    {
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined,
        /// <summary>
        /// Worldstatus Low
        /// </summary>
        Low,
        /// <summary>
        /// Worldstatus Medium
        /// </summary>
        Medium,
        /// <summary>
        /// Worldstatus High
        /// </summary>
        High,
        /// <summary>
        /// Worldstatus VeryHigh
        /// </summary>
        VeryHigh,
        /// <summary>
        /// Worldstatus Full
        /// </summary>
        Full
    }
}
