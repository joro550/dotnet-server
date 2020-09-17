using System;
using System.Collections.Generic;

namespace GlobalServer.Properties.Request.Converters
{
    public static class RequestTypeFactory
    {
        private static readonly Dictionary<string, Type> Requests = new Dictionary<string, Type>
        {
            {"get", typeof(GetRequest)},
            {"post", typeof(PostRequest)},
            {"put", typeof(PutRequest)},
            {"delete", typeof(DeleteRequest)},
            {"head", typeof(HeadRequest)},
            // {"options", typeof(OptionsRequest)},
        };

        public static Type GetDescription(string method) =>
            Requests.ContainsKey(method) 
                ? Requests[method] 
                : typeof(NullRequest);
    }
}