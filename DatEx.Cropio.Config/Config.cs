using System;
using System.IO;
using Newtonsoft.Json;

namespace DatEx.Cropio.Config
{
    public class Config
    {
        [JsonConverter(typeof(JsonConverter_ServerType))]
        [JsonProperty("UsedServer")]
        public ServerType UsedServer { get; set; }

        private Config() {}

        public static Config Load(String filePath)
        {
            if (String.IsNullOrEmpty(filePath)) throw new ArgumentNullException(nameof(filePath));
            return JsonConvert.DeserializeObject<Config>(File.ReadAllText(filePath));
        }
    }
}
