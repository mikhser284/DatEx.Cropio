using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DatEx.Cropio.Proxy.Model
{
    [JsonObject(Title = "AgentConnectionData")]
    public class AgentConnectionData
    {
        [JsonProperty("AgentLogin")]
        public String Login { get; set; }

        [JsonProperty("AgentPassword")]
        public String Password { get; set; }

        [JsonProperty("CropioServerAddress")]
        public String CropioServerAddress { get; set; }
    }
}
