using GlobalServer.Properties.Response.Models;
using Newtonsoft.Json;

namespace GlobalServer.Properties.Response
{
    public class ResponseFromString : SingleResponseBase
    {
        [JsonProperty("content")]
        public string Content { get; set; }
        
        protected override string GetResponse() 
            => Content;
    }
}