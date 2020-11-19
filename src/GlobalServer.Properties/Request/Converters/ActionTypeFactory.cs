using System;
using System.Collections.Generic;
using GlobalServer.Properties.Request.Actions;

namespace GlobalServer.Properties.Request.Converters
{
    public static class ActionTypeFactory
    {
        private static readonly Dictionary<string, Type> Requests = new Dictionary<string, Type>
        {
            {"callUrl", typeof(CallUrl)},
        };

        public static Type GetDescription(string method) =>
            Requests.ContainsKey(method) 
                ? Requests[method] 
                : typeof(NullRequest);
    }
}