using System.Net;
using System.Net.Mime;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace GlobalServer.Properties.Response
{
    public class ResponseDescription : ResponseBase
    {
        public override string Keyword => "response";

        [JsonProperty("body")]
        public object Body { get; set; }
        
        public override string GetContentType() 
            => MediaTypeNames.Application.Json;

        public override string GetResponse()
            => JsonConvert.SerializeObject(Body);
    }

    public abstract class ResponseBase
    {
        public abstract string Keyword { get; }

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