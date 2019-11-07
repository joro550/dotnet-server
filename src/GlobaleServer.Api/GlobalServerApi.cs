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

        public static void SetSettings(IServerSettings settings)
        {
            Configuration.Instance.Settings = settings;

        }
        
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(builder =>
                {
//                    builder.UseUrls("http://localhost:9000", "https://localhost:9001");
                    builder.UseStartup<Startup>();
                });
        }
    }
}
