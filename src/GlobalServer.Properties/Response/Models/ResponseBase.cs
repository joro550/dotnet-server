using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace GlobalServer.Properties.Response.Models
{
    public abstract class ResponseBase
    {
        protected abstract int GetStatusCode();
        protected abstract IHeaderDictionary GetHeaders();
        protected abstract string GetContentType();
        protected abstract string GetResponse();

        protected IHeaderDictionary FromHeaderDescription(IEnumerable<HeaderDescription> headers)
        {
            var headerDescriptions = headers as HeaderDescription[] ?? headers.ToArray();
            if (headerDescriptions == null || !headerDescriptions.Any())
                return new HeaderDictionary();
            
            var headerDictionary = new HeaderDictionary();
            foreach (var (key, value) in headerDescriptions) 
                headerDictionary.Add(key, value);
            return headerDictionary;
        }

        public virtual Models.Response GetResponseModel() =>
            new Models.Response
            {
                Content = GetResponse(),
                StatusCode = GetStatusCode(),
                ContentType = GetContentType(),
                HeaderDictionary = GetHeaders(),
            };
    }
}