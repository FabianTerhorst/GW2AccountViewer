using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GW2AccountViewer
{
    public class Currency
    {
        public Currency()
        {

        }

        [JsonProperty(PropertyName = "id")]
        public Int32 Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public String Description { get; set; }

        [JsonProperty(PropertyName = "order")]
        public Int32 Order { get; set; }

        [JsonProperty(PropertyName = "icon")]
        public String Icon { get; set; }

        public Int32 Value { get; set; }

    }
}
