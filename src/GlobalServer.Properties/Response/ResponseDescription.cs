using System.Net.Mime;
using Newtonsoft.Json;

namespace GlobalServer.Properties.Response
{
    public class ResponseDescription : ResponseBase
    {
        [JsonProperty("body")]
        public object Body { get; set; }
        
        public override string GetContentType() 
            => MediaTypeNames.Application.Json;

        public override string GetResponse()
            => JsonConvert.SerializeObject(Body);
    }
}