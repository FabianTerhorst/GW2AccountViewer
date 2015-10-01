using GW2CSharp.Enums;
using System;
using System.Collections.Generic;

namespace GW2CSharp.V2.Unauthenticated.Continents
{
    /// <summary>
    /// Represents a continent of the v2/continents endpoint.
    /// </summary>
    public class Continent : ApiBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Continent"/> class.
        /// </summary>
        /// <param name="id">The id of the continent.</param>
        /// <param name="name">The name of the continent.</param>
        /// <param name="continent_dims">The width and height dimensions of the continent.</param>
        /// <param name="min_zoom">The minimal zoom level for use with the map tile service.</param>
        /// <param name="max_zoom">The maximum zoom level for use with the map tile service.</param>
        /// <param name="floors">A list of floors available for this continent.</param>
        public Continent(int id, string name, List<int> continent_dims, int min_zoom, int max_zoom, IEnumerable<int> floors)
        {
            Id = id;
            Name = name;
            Dimension = new Coordinate<int>(continent_dims[0], continent_dims[1]);
            MinZoom = min_zoom;
            MaxZoom = max_zoom;

            this.floorIds = floors;
        }

        /// <summary>
        /// The id of the continent.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// The name of the continent.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The width and height dimensions of the continent.
        /// </summary>
        public Coordinate<int> Dimension { get; private set; }

        /// <summary>
        /// The minimal zoom level for use with the map tile service.
        /// </summary>
        public int MinZoom { get; private set; }

        /// <summary>
        /// The maximum zoom level for use with the map tile service.
        /// </summary>
        public int MaxZoom { get; private set; }

        /// <summary>
        /// A list of floors available for this continent.
        /// </summary>
        public Dictionary<int, Lazy<Floor>> Floors 
        {
            get 
            {
                if (convertedFloors == null)
                {
                    convertedFloors = new Dictionary<int, Lazy<Floor>>();
                    foreach (var floorId in floorIds)
                    {
                        convertedFloors.Add(floorId, new Lazy<Floor>(() => GetFloor(floorId)));
                    }
                }

                return convertedFloors;
            }
        }

        internal Floor GetFloor(int floorId) 
        {
            string url = string.Format("https://api.guildwars2.com/v2/continents/{0}/floors/{1}?lang={2}", Id, floorId, Language);
            return DeserializeObject<Floor>(url);
        }

        internal IEnumerable<int> floorIds;

        internal Dictionary<int, Lazy<Floor>> convertedFloors;

        internal RequestedLanguage Language;
    }
}
