using System;
using System.Runtime.Serialization;

namespace GW2CSharp
{
    /// <summary>
    /// Exception that has been made by the API.
    /// </summary>
    public class ApiException : Exception
    {
        /// <summary>
        /// ApiException.
        /// </summary>
        /// <param name="message">Message of the Exception.</param>
        public ApiException(string message)
            : base(message) 
        {
        }
    }
}
