using System;
using Newtonsoft.Json;

namespace DatEx.Cropio.Config
{
    public class ConfigMain
    {
        [JsonProperty("FilePath-Config")]
        public String FilePathConfig { get; set; }

        [JsonProperty("FilePath-ConnectionsConfig")]
        public String FilePathConnectionsConfig { get; set; }
    }
}
