using System.Collections.Generic;
using System.Net;

namespace GlobalServer.Properties.Response
{
    public class ResponseDescription
    {
        public HttpStatusCode StatusCode { get; set; }
        public List<HeaderDescription> Headers { get; set; }
        public object Body { get; set; }
    }
}