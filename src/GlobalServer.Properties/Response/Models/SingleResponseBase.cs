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

        [JsonProperty("headers")]
        public List<HeaderDescription> Headers { get; set; }

        protected override int GetStatusCode() 
            => (int) StatusCode;


        protected override IHeaderDictionary GetHeaders()
        {
            var headerDictionary = new HeaderDictionary();
            foreach (var headers in Headers) 
                headerDictionary.Add(headers.Key, headers.Value);
            return headerDictionary;
        }
    }
}