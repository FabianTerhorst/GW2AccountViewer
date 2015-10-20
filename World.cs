using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GW2AccountViewer
{
    public class World
    {
        public World()
        {

        }

        [JsonProperty(PropertyName = "id")]
        public Int32 Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "population")]
        public String Population { get; set; }
        
    }
}
