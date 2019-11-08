using System;
using System.Collections.Generic;

namespace GlobalServer.Properties.Response.Converters
{
    public static class ResponseTypeFactory
    {
        private static readonly Dictionary<string, Type> ResponseTypes = new Dictionary<string, Type>
        {
            { "response", typeof(ResponseDescription) }
        };

        public static Type GetResponse(string responseType) 
            => ResponseTypes.ContainsKey(responseType) 
                ? ResponseTypes[responseType] 
                : typeof(UnknownResponse);
    }
}