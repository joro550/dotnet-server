using System.Collections.Generic;
using Newtonsoft.Json;

namespace GlobalServer.Properties
{
    public interface ISettings
    {
        Server Server { get; set; }
        List<ServerInteraction> Interactions { get; }
    }

    internal class Settings : ISettings
    {
        [JsonProperty("server")]
        public Server Server { get; set; }

        [JsonProperty("interactions")]
        public List<ServerInteraction> Interactions { get; set; }
    }
}