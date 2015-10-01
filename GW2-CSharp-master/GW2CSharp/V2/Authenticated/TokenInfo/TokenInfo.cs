using Newtonsoft.Json;
using System.Collections.Generic;

namespace GW2CSharp.V2.Authenticated.TokenInfo
{
    /// <summary>
    /// Represents a single tokeninfo from the v2/tokeninfo endpoint.
    /// </summary>
    public class Tokeninfo
    {
        /// <summary>
        /// Initialization of a new tokeninfo object.
        /// </summary>
        /// <param name="id">The API key that was requested.</param>
        /// <param name="name">The name given to the API key by the account owner.</param>
        /// <param name="permissions">Describes which permissions the API key has granted.</param>
        public Tokeninfo(string id, string name, List<string> permissions)
        {
            Id = id;
            Name = name;
            Permission = new Permission(permissions);
        }

        /// <summary>
        /// The API key that was requested.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// The name given to the API key by the account owner.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Describes which permissions the API key has granted.
        /// </summary>
        public Permission Permission { get; private set; }
    }
}
