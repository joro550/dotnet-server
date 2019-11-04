using System.Text;
using System.Net.Http;
using System.Net.Mime;
using Newtonsoft.Json;
using System.Threading.Tasks;
using GlobalServer.Properties;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;

namespace GlobalServer.Api
{
    public static class GlobalServerApi
    {
        public static void Main()
        {
//            CreateHostBuilder(args).Build().Run();
        }
        
        public static IHostBuilder CreateHostBuilder(ServerSettings settings)
        {
            return Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.Configure((context, builder) =>
                    {
                        builder.UseHttpsRedirection();
                        builder.UseRouting();
                        builder.UseEndpoints(endpoints =>
                        {
                            foreach (var interaction in settings.Interactions)
                            {
                                endpoints.MapGet(interaction.Request.Path,
                                     httpContext => Task.FromResult(HandleRequest(interaction.Response)));
                            }
                        });
                    });
                });
        }

        private static HttpResponseMessage HandleRequest( ResponseDescription response)
        {
            return new HttpResponseMessage(response.StatusCode)
            {
                Content = new StringContent(JsonConvert.SerializeObject(response.Body), Encoding.UTF8,
                    MediaTypeNames.Application.Json)
            };
        }
    }
}
