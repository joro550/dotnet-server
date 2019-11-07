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
}