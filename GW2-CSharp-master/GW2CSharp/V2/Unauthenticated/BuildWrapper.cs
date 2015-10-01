using Newtonsoft.Json;

namespace GW2CSharp.V2.Unauthenticated.Miscellaneous
{
    internal class BuildWrapper : ApiBase
    {
        internal static int GetId()
        {
            var definition = new { Id = 0 };
            string jsonString = DownloadJsonString("https://api.guildwars2.com/v2/build");

            return JsonConvert.DeserializeAnonymousType(jsonString, definition).Id;
        }
    }
}
