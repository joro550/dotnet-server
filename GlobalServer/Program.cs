using System;
using System.IO.Abstractions;
using System.Threading;
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
