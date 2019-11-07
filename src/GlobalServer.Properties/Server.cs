using System.Collections.Generic;
using Newtonsoft.Json;

namespace GlobalServer.Properties
{
    public class Server
    {
        [JsonProperty("sslEnabled")]
        public bool SslEnabled { get; set; }

        [JsonProperty("ports")]
        public List<PortSettings> Ports { get; set; }
    }
}