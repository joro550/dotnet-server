using System;
using System.Collections.Generic;
using Config.Net;
using GlobalServer.Server;
using GlobalServer.Settings;
using System.Threading.Tasks;
using System.Windows.Input;
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

            var command = CommandFactory.GetCommand(commandLineSettings);
            await command.Run();
            
            Console.ReadKey();
        }
    }

    public interface ICommandRunner
    {
        Task Run();
    }

    internal class ServerRunner : ICommandRunner
    {
        private readonly IGlobalServerSettings _commandLineSettings;

        public ServerRunner(IGlobalServerSettings commandLineSettings)
        {
            _commandLineSettings = commandLineSettings;
        }

        public async Task Run()
        {
            using var server = new ServerImpl(_commandLineSettings);
            var runResult = await server.Run();

            if (!runResult.Success)
            {
                var errors = runResult.Accept(new GetErrors());
                foreach (var error in errors) Console.WriteLine(error);
            }
        }
    }

    public class NullCommand : ICommandRunner
    {
        public Task Run() 
            => Task.CompletedTask;
    }

    internal static class CommandFactory
    {
        private static Dictionary<string, Func<IGlobalServerSettings, ICommandRunner>> Commands { get; } =
            new Dictionary<string, Func<IGlobalServerSettings, ICommandRunner>>
            {
                {"run-server", s => new ServerRunner(s)}
            };


        public static ICommandRunner GetCommand(IGlobalServerSettings commandLineSettings)
        {
            if (Commands.ContainsKey(commandLineSettings.Command))
                return Commands[commandLineSettings.Command](commandLineSettings);
            return new NullCommand();
        }
    }
}

