using GlobalServer.Properties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using GlobalServer.Properties.Request;
using static System.Net.Http.HttpMethod;
using GlobalServer.Properties.Request.Queries;

namespace GlobalServer.Api
{
    public class AddRouting : QueryVisitor
    {
        private readonly ServerInteraction _response;
        private readonly IEndpointRouteBuilder _builder;

        public AddRouting(IEndpointRouteBuilder builder, ServerInteraction response)
        {
            _builder = builder;
            _response = response;
        }

        public override void VisitGetDescription(GetRequest element) 
            => _builder.MapGet(element.Path, RequestDelegate());

        public override void VisitDeleteDescription(DeleteRequest element) 
            => _builder.MapDelete(element.Path, RequestDelegate());

        public override void VisitPostDescription(PostRequest element) 
            => _builder.MapPost(element.Path, RequestDelegate());

        public override void VisitPutDescription(PutRequest element) 
            => _builder.MapPut(element.Path, RequestDelegate());

        public override void VisitHeadDescription(HeadRequest element) 
            => _builder.MapMethods(element.Path, new []{ Head.Method }, RequestDelegate());

        public override void VisitOptionsDescription(OptionsRequest element)
            => _builder.MapMethods(element.Path, new []{ Options.Method }, RequestDelegate());

        public override void VisitNullDescription()
        {
        }

        private RequestDelegate RequestDelegate() =>
            async httpContext =>
            {
                var requestAction = _response.OnRequestAction();
                var response = _response.GetResponse();
                
                foreach (var (key, value) in response.HeaderDictionary)
                    httpContext.Response.Headers.Add(key, value);

                httpContext.Response.StatusCode = response.StatusCode;
                httpContext.Response.ContentType = response.ContentType;
                await httpContext.Response.WriteAsync(response.Content);
                await requestAction;
            };
    }
}