using System;
using System.Collections.Generic;

namespace GlobalServer.Properties.Response.Converters
{
    public static class ResponseTypeFactory
    {
        private static readonly Dictionary<string, Type> ResponseTypes = new Dictionary<string, Type>
        {
            {"response", typeof(ResponseDescription)},
            {"incrementalList", typeof(IncrementalListResponse)},
            {"randomList", typeof(RandomFromListResponse)},
            {"fromFile", typeof(ResponseFromFile)},
            {"fromString", typeof(ResponseFromString)}
        };

        public static Type GetResponse(string responseType) 
            => ResponseTypes.ContainsKey(responseType) 
                ? ResponseTypes[responseType] 
                : typeof(UnknownResponse);
    }
}