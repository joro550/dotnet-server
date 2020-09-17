using System.Collections.Generic;
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
            var headerDictionary = new HeaderDictionary();
            foreach (var (key, value) in headers) 
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