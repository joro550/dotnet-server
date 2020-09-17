using System;
using GlobalServer.Server;
using GlobalServer.Settings;
using System.Collections.Generic;

namespace GlobalServer
{
    internal static class CommandFactory
    {
        private static Dictionary<string, Func<IGlobalServerSettings, ICommandRunner>> Commands { get; } =
            new Dictionary<string, Func<IGlobalServerSettings, ICommandRunner>>
            {
                {"run-server", settings => new ServerRunner(settings)}
            };

        public static ICommandRunner GetCommand(IGlobalServerSettings commandLineSettings) =>
            Commands.ContainsKey(commandLineSettings.Command)
                ? Commands[commandLineSettings.Command](commandLineSettings)
                : new ServerRunner(commandLineSettings);
    }
}