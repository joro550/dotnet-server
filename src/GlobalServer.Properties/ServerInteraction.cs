using Newtonsoft.Json;
using GlobalServer.Properties.Request;
using GlobalServer.Properties.Response;
using GlobalServer.Properties.Request.Converters;
using GlobalServer.Properties.Response.Converters;

namespace GlobalServer.Properties
{
    public class ServerInteraction
    {
        [JsonProperty("request")]
        [JsonConverter(typeof(RequestConverter))]
        public RequestBase Request { get; set; }

        [JsonConverter(typeof(ResponseConverter))]
        public ResponseBase Response { get; set; }
    }
}