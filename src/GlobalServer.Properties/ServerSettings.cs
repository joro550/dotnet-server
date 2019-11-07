using System.Collections.Generic;
using Newtonsoft.Json;

namespace GlobalServer.Properties
{
    public interface IServerSettings
    {
        List<ServerInteraction> Interactions { get; }
    }

    internal class ServerSettings : IServerSettings
    {
        [JsonProperty("server")]
        public Server Server { get; set; }

        [JsonProperty("interactions")]
        public List<ServerInteraction> Interactions { get; set; }
    }

    public class Server
    {
        [JsonProperty("sslEnabled")]
        public bool SslEnabled { get; set; }

        [JsonProperty("ports")]
        public List<PortSettings> Ports { get; set; }
    }

    public class PortSettings
    {
        [JsonProperty("isSecure")]
        public bool IsSecure { get; set; }

        [JsonProperty("portNumber")]
        public int PortNumber { get; set; }
    }
}