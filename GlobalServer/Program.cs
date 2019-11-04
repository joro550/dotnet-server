using System.IO.Abstractions;
using Config.Net;
using GlobalServer.Api;
using System.Threading.Tasks;
using GlobalServer.Properties;

namespace GlobalServer
{
    internal static class Program
    {
        private static async Task Main()
        {
            var commandLineSettings = new ConfigurationBuilder<IGlobalServerSettings>()
                .UseCommandLineArgs()
                .Build();

            var loader = new SettingsLoader(new FileSystem());
            var serverSettings = await loader.Load(commandLineSettings.FileName);

            await GlobalServerApi
                .CreateHostBuilder(serverSettings)
                .Build()
                .StartAsync();
        }
    }
}
