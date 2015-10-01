using System;
using System.Collections.Generic;

namespace GW2CSharp.V2.Unauthenticated.Continents
{
    /// <summary>
    /// Represents the v2/maps endpoint.
    /// </summary>
    public class Map
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class.
        /// </summary>
        /// <param name="name">The map name.</param>
        /// <param name="min_level">The minimum level.</param>
        /// <param name="max_level">The maximum level.</param>
        /// <param name="default_floor">The default floor.</param>
        /// <param name="map_rect">The dimensions of the map, given as the coordinates of the lower-left (SW) and upper-right (NE) corners.</param>
        /// <param name="continent_rect">The dimensions of the map within the continent coordinate system, given as the coordinates of the upper-left (NW) and lower-right (SE) corners.</param>
        /// <param name="points_of_interest">The pois.</param>
        /// <param name="tasks">The objectives.</param>
        /// <param name="skill_challenges">The skill challenges.</param>
        /// <param name="sectors">The sectors.</param>
        public Map(string name, int min_level, int max_level, int default_floor, List<List<int>> map_rect, List<List<int>> continent_rect,
            Dictionary<string, Lazy<Poi>> points_of_interest, Dictionary<string, Lazy<Objective>> tasks, IEnumerable<Lazy<SkillChallenge>> skill_challenges, Dictionary<string, Lazy<Sector>> sectors)
        {
            Name = name;
            MinLevel = min_level;
            MaxLevel = max_level;
            DefaultFloor = default_floor;
            MapRectangle = new Rectangle(map_rect[0], map_rect[1]);
            ContinentRectangle = new Rectangle(continent_rect[0], continent_rect[1]);
            PointsOfInterest = points_of_interest;
            Objectives = tasks;
            SkillChallenges = skill_challenges;
            Sectors = sectors;
        }

        /// <summary>
        /// The map name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the minimum level.
        /// </summary>
        public int MinLevel { get; private set; }

        /// <summary>
        /// Gets the maximum level.
        /// </summary>
        public int MaxLevel { get; private set; }

        /// <summary>
        /// Gets the default floor.
        /// </summary>
        public int DefaultFloor { get; private set; }

        /// <summary>
        /// The dimensions of the map, given as the coordinates of the lower-left (SW) and upper-right (NE) corners.
        /// </summary>
        public Rectangle MapRectangle { get; private set; }

        /// <summary>
        /// Gets the continent rectangle.
        /// </summary>
        public Rectangle ContinentRectangle { get; private set; }

        /// <summary>
        /// Gets the points of interest.
        /// </summary>
        public Dictionary<string, Lazy<Poi>> PointsOfInterest { get; private set; }

        /// <summary>
        /// Gets the objectives.
        /// </summary>
        public Dictionary<string, Lazy<Objective>> Objectives { get; private set; }

        /// <summary>
        /// Gets the skill challenges.
        /// </summary>
        public IEnumerable<Lazy<SkillChallenge>> SkillChallenges { get; private set; }

        /// <summary>
        /// Gets the sectors.
        /// </summary>
        public Dictionary<string, Lazy<Sector>> Sectors { get; private set; }
    }
}
