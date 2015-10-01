using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GW2AccountViewer
{
    public class Account
    {

        public Account()
        {

        }

        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "guilds")]
        public List<String> Guilds { get; set; }

    }
}
