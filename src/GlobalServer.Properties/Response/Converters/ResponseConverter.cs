using System;
using GlobalServer.Properties.Response.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GlobalServer.Properties.Response.Converters
{
    public class ResponseConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) 
            => throw new NotImplementedException();
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);
            var hasType = jo.TryGetValue("type", StringComparison.CurrentCultureIgnoreCase, out var typeToken);

            return hasType
                ? jo.ToObject(GetResponseType(typeToken))
                : jo.ToObject<ResponseDescription>();
        }

        private static Type GetResponseType(JToken type)
            => ResponseTypeFactory.GetResponse(type.Value<string>());

        public override bool CanConvert(Type objectType)
            => objectType == typeof(ResponseBase) || objectType == typeof(ResponseBase);
    }
}