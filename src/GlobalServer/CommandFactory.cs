using System;
using GlobalServer.Server;
using GlobalServer.Settings;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GlobalServer
{
    internal static class CommandFactory
    {
        private static Dictionary<string, Func<IGlobalServerSettings, ICommandRunner>> Commands { get; } =
            new Dictionary<string, Func<IGlobalServerSettings, ICommandRunner>>
            {
                {"run-server", s => new ServerRunner(s)}
            };

        public static ICommandRunner GetCommand(IGlobalServerSettings commandLineSettings) =>
            Commands.ContainsKey(commandLineSettings.Command)
                ? Commands[commandLineSettings.Command](commandLineSettings)
                : new NullCommand();

        private class NullCommand : ICommandRunner
        {
            public Task Run()
                => Task.CompletedTask;

            public void Dispose()
            {
            }
        }
    }
}