using GlobalServer.Properties;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;

namespace GlobalServer.Api
{
    public static class GlobalServerApi
    {
        public static void Main()
        {
        }
        
        public static IHostBuilder CreateHostBuilder(IServerSettings settings)
        {
            Thing.Instance.Settings = settings;
            return Host.CreateDefaultBuilder().ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
        }
    }

    public class Thing
    {
        public static Thing Instance { get; } = new Thing();
        public IServerSettings Settings { get; set; }
    }
}
