using System;
using Newtonsoft.Json;

namespace DatEx.Cropio.Config
{
    public class ConnectionInfo
    {
        [JsonConverter(typeof(JsonConverter_ServerType))]
        [JsonProperty("ServerType")]
        public ServerType ServerType { get; set; }

        [JsonProperty("ServerBaseAddress")]
        public String ServerBaseAddress { get; set; }

        [JsonProperty("AgentLogin")]
        public String AgentLogin { get; set; }

        [JsonProperty("AgentPassword")]
        public String AgentPassword { get; set; }

        public ConnectionInfo() { }

        public override string ToString()
        {
            return ServerType.AsString();
        }
    }
}
