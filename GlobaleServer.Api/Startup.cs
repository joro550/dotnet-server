using Newtonsoft.Json;
using Microsoft.AspNetCore.Builder;
using GlobalServer.Properties.Response;

namespace GlobalServer.Api
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                foreach (var interaction in Thing.Instance.Settings.Interactions)
                {
                    var addRoutingRequest = new AddRouting(endpoints, interaction.Response);
                    interaction.Request.Accept(addRoutingRequest);
                }
            });
        }

        private static string HandleRequest(ResponseDescription response) 
            => JsonConvert.SerializeObject(response.Body);
    }
}