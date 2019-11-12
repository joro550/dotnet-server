using System;
using System.Threading.Tasks;
using GlobalServer.Server.Visitors;
using GlobalServer.Settings;

namespace GlobalServer.Server
{
    internal class ServerRunner : ICommandRunner
    {
        private ServerImpl _server;
        private readonly IGlobalServerSettings _commandLineSettings;

        public ServerRunner(IGlobalServerSettings commandLineSettings)
        {
            _commandLineSettings = commandLineSettings;
        }

        public async Task Run()
        {
            _server = new ServerImpl(_commandLineSettings);
            var runResult = await _server.Run();

            if (!runResult.Success)
            {
                var errors = runResult.Accept(new GetErrors());
                foreach (var error in errors) Console.WriteLine(error);
            }
        }

        public void Dispose()
        {
            _server?.Dispose();
        }
    }
}