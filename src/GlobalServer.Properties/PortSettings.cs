using Newtonsoft.Json;

namespace GlobalServer.Properties
{
    public class PortSettings
    {
        [JsonProperty("isSecure")]
        public bool IsSecure { get; set; }

        [JsonProperty("portNumber")]
        public int PortNumber { get; set; }
    }
}