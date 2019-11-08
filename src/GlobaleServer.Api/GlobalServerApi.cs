using System.Linq;
using GlobalServer.Properties;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;

namespace GlobalServer.Api
{
    public class GlobalServerApi
    {
        public static void Main()
        {
        }

        public static void SetSettings(ISettings settings)
        {
            Configuration.Instance.Settings = settings;
        }
        
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(builder =>
                {
                    var ports = Configuration.Instance.Settings?.Server?.Ports;
                    if (ports != null && ports.Any())
                    {
                        var urlList = ports.Select(settings =>
                            settings.IsSecure
                                ? $"https://localhost:{settings.PortNumber}"
                                : $"http://localhost:{settings.PortNumber}");
                        builder.UseUrls(urlList.ToArray());
                    }

                    builder.UseStartup<Startup>();
                });
        }
    }
}
