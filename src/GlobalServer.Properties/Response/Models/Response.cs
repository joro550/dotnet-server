using Microsoft.AspNetCore.Http;

namespace GlobalServer.Properties.Response.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public IHeaderDictionary HeaderDictionary { get; set; }
        public string ContentType { get; set; }
        public string Content { get; set; }
    }
}