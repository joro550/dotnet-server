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
            => _builder.MapGet(element.Path, RequestDelegate());

        public override void VisitDeleteDescription(DeleteRequestDescription element) 
            => _builder.MapDelete(element.Path, RequestDelegate());

        public override void VisitPostDescription(PostRequestDescription element) 
            => _builder.MapPost(element.Path, RequestDelegate());

        public override void VisitPutDescription(PutRequestDescription element) 
            => _builder.MapPut(element.Path, RequestDelegate());

        public override void VisitNullDescription(NullRequestDescription element)
        {
        }

        private RequestDelegate RequestDelegate() =>
            async httpContext =>
            {
                foreach (var (key, value) in _response.GetHeaders())
                    httpContext.Response.Headers.Add(key, value);

                httpContext.Response.StatusCode = _response.GetStatusCode();
                httpContext.Response.ContentType = _response.GetContentType();
                await httpContext.Response.WriteAsync(_response.GetResponse());
            };
    }
}