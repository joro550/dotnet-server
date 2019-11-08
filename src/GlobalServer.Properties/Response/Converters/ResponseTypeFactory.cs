using System.Linq;
using System.Collections.Generic;

namespace GlobalServer.Properties.Response.Converters
{
    public class ResponseTypeFactory
    {
        private static readonly List<ResponseBase> Responses = new List<ResponseBase>
        {
            new ResponseDescription()
        };

        public static ResponseBase GetResponse(string method) =>
            Responses.FirstOrDefault(requestDescription => requestDescription.Keyword == method) 
            ?? new UnknownResponse();
    }
}