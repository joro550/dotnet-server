using System.Net.Mime;
using GlobalServer.Properties.Response.Models;
using Newtonsoft.Json;

namespace GlobalServer.Properties.Response
{
    public class ResponseDescription : SingleResponseBase
    {
        [JsonProperty("body")]
        public object Body { get; set; }

        protected override string GetContentType() 
            => MediaTypeNames.Application.Json;

        protected override string GetResponse()
            => JsonConvert.SerializeObject(Body);
    }
}