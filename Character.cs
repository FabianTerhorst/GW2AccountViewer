using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GW2AccountViewer
{
    public class Character
    {

        public Character()
        {

        }

        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "id")]
        public Int32 Id { get; set; }

        [JsonProperty(PropertyName = "guild")]
        public String GuildId { get; set; }

        [JsonProperty(PropertyName = "equipment")]
        public List<Equipment> Equipment { get; set; }

    }
}
