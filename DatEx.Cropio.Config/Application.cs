using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace DatEx.Cropio.Config
{
    public static class Applitation
    {
        public static Config Config { get; set; }

        public static ConnectionsConfig ConnectionsConfig { get; set; }

        public static ConnectionInfo UsedConnection { get; private set; }

        static Applitation()
        {
            var workDir = Environment.CurrentDirectory;
            Directory.SetCurrentDirectory(@"..\..\..\");
            String currentDir = Environment.CurrentDirectory;
            ConfigMain main = JsonConvert.DeserializeObject<ConfigMain>(File.ReadAllText(@"!Config CropioProxy-Main.json"));
            Config = Config.Load(main.FilePathConfig);
            ConnectionsConfig = ConnectionsConfig.Load(main.FilePathConnectionsConfig);

            UsedConnection = ConnectionsConfig.ServerConnections.Where(x => x.ServerType == Config.UsedServer).FirstOrDefault();

            Directory.SetCurrentDirectory(workDir);
        }
    }

    
}
