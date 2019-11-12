using System;
using System.Collections.Generic;
using GlobalServer.Server;
using GlobalServer.Settings;

namespace GlobalServer
{
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