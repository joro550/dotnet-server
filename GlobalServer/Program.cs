using System;
using System.Linq;
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

            var settingsValidator = new SettingsValidator();
            var validationResult = await settingsValidator.ValidateAsync(commandLineSettings);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(failure => failure.ErrorMessage);
                foreach (var error in errors) Console.WriteLine(error);
                return;
            }

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
