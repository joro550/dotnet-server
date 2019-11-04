using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GlobalServer.Properties.Request.Converters
{
    internal class RequestConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);
            var method = jo.GetValue("method").Value<string>().ToLower();

            switch (method)
            {
                case "get":
                    return jo.ToObject<GetRequestDescription>();
            }

            return jo.ToObject<NullRequestDescription>();
        }

        public override bool CanConvert(Type objectType)
            => objectType == typeof(RequestDescription) || objectType == typeof(RequestDescription);
    }
}