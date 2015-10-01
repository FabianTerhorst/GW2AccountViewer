using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace GW2CSharp
{
    /// <summary>
    /// Base class for all coming endpoint calls.
    /// </summary>
    public class ApiBase
    {
        /// <summary>
        /// Downloads a JsonString from a url.
        /// </summary>
        /// <param name="url">Url.</param>
        /// <returns>JsonString from url.</returns>
        public static string DownloadJsonString(string url)
        {
            string jsonString = string.Empty;
            
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = Encoding.GetEncoding("utf-8");
                    jsonString = wc.DownloadString(url);
                }
            }
            catch (WebException exception)
            {
                if (exception.Response != null)
                {
                    var responseStream = exception.Response.GetResponseStream();

                    if (responseStream != null)
                    {
                        using (var reader = new StreamReader(responseStream))
                        {
                            string responseText = reader.ReadToEnd().Replace("{\"text\":\"", "").Replace("\"}", "");
                            throw new ApiException(responseText);
                        }
                    }
                }
            }

            return jsonString;
        }

        /// <summary>
        /// Deserializes a object.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="url">Endpoint url.</param>
        /// <returns>Converted object.</returns>
        public static T DeserializeObject<T>(string url)
        {
            return JsonConvert.DeserializeObject<T>(DownloadJsonString(url));
        }
    }
}
