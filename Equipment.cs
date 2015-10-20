using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GW2AccountViewer
{
    public class Equipment
    {
        public Equipment()
        {

        }

        [JsonProperty(PropertyName = "id")]
        public Int32 Id { get; set; }

        [JsonProperty(PropertyName = "slot")]
        public String Slot { get; set; }

    }
}
