using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalServer.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                foreach (var interaction in Configuration.Instance.Settings.Interactions)
                {
                    var addRoutingRequest = new AddRouting(endpoints, interaction.Response);
                    interaction.Request.Accept(addRoutingRequest);
                }
            });
        }
    }
}