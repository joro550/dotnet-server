using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace GlobalServer.Properties.Response
{
    public abstract class ResponseBase
    {
        [JsonProperty("status")]
        public HttpStatusCode StatusCode { get; set; }

        [JsonProperty("headers")]
        public List<HeaderDescription> Headers { get; set; }

        public int GetStatusCode() 
            => (int) StatusCode;

        public IHeaderDictionary GetHeaders()
        {
            var headerDictionary = new HeaderDictionary();
            foreach (var headers in Headers) 
                headerDictionary.Add(headers.Key, headers.Value);
            return headerDictionary;
        }

        public abstract string GetContentType();
        public abstract string GetResponse();
    }
}