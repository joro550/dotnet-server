using System.Collections.Generic;
using System.Linq;

namespace GlobalServer.Properties.Request.Converters
{
    public static class RequestTypeFactory
    {
        private static readonly List<RequestDescription> Descriptions = new List<RequestDescription>
        {
            new GetRequestDescription(),
            new PostRequestDescription(),
            new PutRequestDescription(),
            new DeleteRequestDescription()
        };

        public static RequestDescription GetDescription(string method) =>
            Descriptions.FirstOrDefault(requestDescription => requestDescription.Method == method) 
            ?? new NullRequestDescription();
    }
}