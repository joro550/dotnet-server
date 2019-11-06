using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace GlobalServer.Properties.Response
{
    public class ResponseDescription
    {
        [JsonProperty("status")]
        public HttpStatusCode StatusCode { get; set; }
        public List<HeaderDescription> Headers { get; set; }
        public object Body { get; set; }
    }
}