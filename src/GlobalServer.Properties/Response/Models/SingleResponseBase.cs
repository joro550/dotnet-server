using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace GlobalServer.Properties.Response.Models
{
    public abstract class SingleResponseBase : ResponseBase
    {
        [JsonProperty("status")]
        public HttpStatusCode StatusCode { get; set; }

        [JsonProperty("contentType")] 
        public string ContentType { get; set; }

        [JsonProperty("headers")]
        public List<HeaderDescription> Headers { get; set; }

        protected override int GetStatusCode() 
            => (int) StatusCode;

        protected override string GetContentType() 
            => ContentType;

        protected override IHeaderDictionary GetHeaders() 
            => FromHeaderDescription(Headers);
    }
}