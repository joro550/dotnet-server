using System;
using System.Collections.Generic;
using GlobalServer.Properties.Response.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace GlobalServer.Properties.Response
{
    public class RandomFromListResponse : ResponseBase
    {
        private static int _iterator = 0; 
        private readonly Random _random = new Random();
        
        [JsonProperty("values")]
        public List<ListContent> Values { get; set; }

        protected override int GetStatusCode() 
            => Values[_iterator].StatusCode;

        protected override IHeaderDictionary GetHeaders() 
            => FromHeaderDescription(Values[_iterator].Headers);

        protected override string GetContentType() 
            => Values[_iterator].ContentType;

        protected override string GetResponse() 
            => JsonConvert.SerializeObject(Values[_iterator].Content);

        public override Models.Response GetResponseModel()
        {
            var model = base.GetResponseModel();
            _iterator = _random.Next(0, Values.Count);
            
            if (_iterator >= Values.Count)
                _iterator = 0;
            
            return model;
        }
    }
}