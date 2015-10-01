using GW2CSharp.V2.Unauthenticated.Worlds.Enums;

namespace GW2CSharp.V2.Unauthenticated.Worlds
{
    /// <summary>
    /// Represents a single world from the v2/worlds endpoint.
    /// </summary>
    public class World   
    {
        /// <summary>
        /// Initialization of a new world object.
        /// </summary>
        /// <param name="id">The world Id.</param>
        /// <param name="name">The world name.</param>
        /// <param name="population">The world population level. One of: Low, Medium, High, VeryHigh, Full</param>
        public World(int id, string name, Population population)
        {
            Id = id;
            Name = name;
            Population = population;
        }

        /// <summary>
        /// Returns the Id of this world.
        /// </summary>
        public int Id { get; private set; }
        
        /// <summary>
        /// Returns the Name of this world.
        /// </summary>
        public string Name { get; private set; }
        
        /// <summary>
        /// Returns the Population of this world.
        /// </summary>
        public Population Population { get; private set; }

        /// <summary>
        /// Returns the Region of this world.
        /// </summary>
        public Region Region
        {
            get 
            {
                int regionId = Id / 1000;
                return (Region)regionId;
            }
        }

        /// <summary>
        /// Returns the Language of this world.
        /// </summary>
        public Language Language 
        {
            get 
            {
                int languageId = (Id / 100) % 10;
                return (Language)languageId;
            }
        }
    }
}
