using Newtonsoft.Json;
using GlobalServer.Properties.Request;
using GlobalServer.Properties.Request.Converters;
using GlobalServer.Properties.Response;

namespace GlobalServer.Properties
{
    public class ServerInteraction
    {
        [JsonProperty("request")]
        [JsonConverter(typeof(RequestConverter))]
        public RequestDescription Request { get; set; }
        
        [JsonProperty("response")]
        public ResponseDescription Response { get; set; }
    }
}