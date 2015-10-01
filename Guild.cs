using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GW2AccountViewer
{
    public class Guild
    {

        public Guild()
        {

        }

        [JsonProperty(PropertyName = "guild_name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "guild_id")]
        public String Id { get; set; }

        [JsonProperty(PropertyName = "tag")]
        public String Tag { get; set; }

    }
}
