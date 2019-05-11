using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace DatEx.Cropio.Config
{
    public class ConnectionsConfig
    {
        public List<ConnectionInfo> ServerConnections { get; set; } = new List<ConnectionInfo>();

        private ConnectionsConfig() { }

        public static ConnectionsConfig Load(String filePath)
        {
            if (String.IsNullOrEmpty(filePath)) throw new ArgumentNullException(nameof(filePath));
            return JsonConvert.DeserializeObject<ConnectionsConfig>(File.ReadAllText(filePath));
        }
    }
}
