
using GW2CSharp.Enums;
using System.Collections.Generic;
namespace GW2CSharp.V2.Unauthenticated.Continents
{
    /// <summary>
    /// Represents a single ContinentWrapper.
    /// </summary>
    public class ContinentWrapper : ApiBase
    {
        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="requestedLanguage">The requested language.</param>
        /// <returns></returns>
        public Continent GetById(int id, RequestedLanguage requestedLanguage = RequestedLanguage.En) 
        {
            Continent continent = DeserializeObject<Continent>(string.Format("https://api.guildwars2.com/v2/continents?id={0}&lang={1}", id, requestedLanguage));
            continent.Language = requestedLanguage;
            return continent;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="requestedLanguage">The requested language.</param>
        /// <returns></returns>
        public IEnumerable<Continent> GetAll(RequestedLanguage requestedLanguage = RequestedLanguage.En)
        {
            return DeserializeObject<IEnumerable<Continent>>(string.Format("https://api.guildwars2.com/v2/continents?ids=all&lang={0}", requestedLanguage));
        }
    }
}
