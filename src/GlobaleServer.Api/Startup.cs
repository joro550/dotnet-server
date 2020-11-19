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
            app.UseEndpoints(routeBuilder =>
            {
                foreach (var interaction in Configuration.Instance.Settings.Interactions)
                {
                    interaction.Request.Accept(new AddRouting(routeBuilder, interaction));
                }
            });
        }
    }
}