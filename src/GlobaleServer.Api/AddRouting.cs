using Newtonsoft.Json;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using GlobalServer.Properties.Request;
using GlobalServer.Properties.Response;
using GlobalServer.Properties.Request.Queries;

namespace GlobalServer.Api
{
    public class AddRouting : Visitor
    {
        private readonly ResponseDescription _response;
        private readonly IEndpointRouteBuilder _builder;

        public AddRouting(IEndpointRouteBuilder builder, ResponseDescription response)
        {
            _builder = builder;
            _response = response;
        }

        public override void VisitGetDescription(GetRequestDescription element)
        {
            _builder.MapGet(element.Path, RequestDelegate());
        }

        public override void VisitDeleteDescription(DeleteRequestDescription element)
        {
            _builder.MapDelete(element.Path, RequestDelegate());
        }

        public override void VisitPostDescription(PostRequestDescription element)
        {
            _builder.MapPost(element.Path, RequestDelegate());
        }

        public override void VisitPutDescription(PutRequestDescription element)
        {
            _builder.MapPut(element.Path, RequestDelegate());
        }

        public override void VisitNullDescription(NullRequestDescription element)
        {
        }

        private RequestDelegate RequestDelegate() =>
            async httpContext =>
            {
                httpContext.Response.StatusCode = (int) _response.StatusCode;
                httpContext.Response.ContentType = MediaTypeNames.Application.Json;
                await httpContext.Response.WriteAsync(HandleRequest(_response));
            };

        private static string HandleRequest(ResponseDescription response) 
            => JsonConvert.SerializeObject(response.Body);
    }
}