using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using GlobalServer.Properties.Request;
using GlobalServer.Properties.Response;
using GlobalServer.Properties.Response.Models;
using GlobalServer.Properties.Request.Converters;
using GlobalServer.Properties.Response.Converters;

namespace GlobalServer.Properties
{
    public class ServerInteraction
    {
        [JsonProperty("request")]
        [JsonConverter(typeof(RequestConverter))]
        public RequestBase Request { get; set; }

        [JsonConverter(typeof(ResponseConverter))]
        public ResponseBase Response { get; set; }
        
        [JsonProperty("where")]
        public List<ConditionalResponse> ConditionalResponse { get; set; }

        public Response.Models.Response GetResponse()
        {
            if (ConditionalResponse == null || !ConditionalResponse.Any())
                return Response.GetResponseModel();
            return Response.GetResponseModel();
        }

        public async Task OnRequestAction() 
            => await Request.Action.Perform();
    }
}