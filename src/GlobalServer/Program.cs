using System;
using Config.Net;
using GlobalServer.Settings;
using System.Threading.Tasks;

namespace GlobalServer
{
    internal static class Program
    {
        private static async Task Main()
        {
            using var commandRunner 
                = CommandFactory.GetCommand(GetSettings());

            await commandRunner.Run();

            // Keep console open
            Console.ReadKey();
        }

        private static IGlobalServerSettings GetSettings() =>
            new ConfigurationBuilder<IGlobalServerSettings>()
                .UseCommandLineArgs()
                .Build();
    }
}

