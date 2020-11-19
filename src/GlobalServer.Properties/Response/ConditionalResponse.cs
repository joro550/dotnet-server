using GlobalServer.Properties.Response.Converters;
using GlobalServer.Properties.Response.Models;
using Newtonsoft.Json;

namespace GlobalServer.Properties.Response
{
    public class ConditionalResponse
    {
        public string Condition { get; set; }
        
        [JsonConverter(typeof(ResponseConverter))]
        public ResponseBase Response { get; set; }
    }
}