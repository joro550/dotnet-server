using GlobalServer.Properties.Response.Models;

namespace GlobalServer.Properties.Response
{
    public class UnknownResponse : SingleResponseBase
    {
        protected override string GetContentType() 
            => string.Empty;

        protected override string GetResponse() 
            => string.Empty;
    }
}