using System;
using Config.Net;
using System.Threading;
using GlobalServer.Api;
using System.Threading.Tasks;
using GlobalServer.Properties.Initialization;

namespace GlobalServer
{
    internal static class Program
    {
        private static async Task Main()
        {
            var commandLineSettings = new ConfigurationBuilder<IGlobalServerSettings>()
                .UseCommandLineArgs()
                .Build();

            var propertiesFactory = PropertiesBuilder.Default();
            var loader = propertiesFactory.GetSettingsLoader();
            var serverSettings = await loader.Load(commandLineSettings.FileName);

            using var serverToken = new CancellationTokenSource();
            using var host = GlobalServerApi
                .CreateHostBuilder(serverSettings)
                .Build();

            await host.StartAsync(serverToken.Token);

            Console.ReadKey();
            serverToken.Cancel();
        }
    }
}
