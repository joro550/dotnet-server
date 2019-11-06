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
            return Host.CreateDefaultBuilder().ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
        }


    }

    public class Configuration
    {
        public static Configuration Instance { get; } = new Configuration();
        public IServerSettings Settings { get; set; }
    }
}
