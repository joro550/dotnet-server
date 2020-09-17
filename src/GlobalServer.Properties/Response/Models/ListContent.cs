using System.Collections.Generic;
using Newtonsoft.Json;

namespace GlobalServer.Properties.Response.Models
{
    public class ListContent
    {
        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }
        
        [JsonProperty("headers")]
        public List<HeaderDescription> Headers { get; set; }
        
        [JsonProperty("content")]
        public object Content { get; set; }
        
        [JsonProperty("contentType")]
        public string ContentType { get; set; }
    }
}