using System;
using Config.Net;
using GlobalServer.Server;
using GlobalServer.Settings;
using System.Threading.Tasks;
using GlobalServer.Server.Visitors;

namespace GlobalServer
{
    internal static class Program
    {
        private static async Task Main()
        {
            var commandLineSettings = new ConfigurationBuilder<IGlobalServerSettings>()
                .UseCommandLineArgs()
                .Build();

            using var server = new ServerImpl(commandLineSettings);
            var runResult = await server.Run();

            if (!runResult.Success)
            {
                var errors = runResult.Accept(new GetErrors());
                foreach (var error in errors) Console.WriteLine(error);
                return;
            }

            Console.ReadKey();
        }
    }
}

