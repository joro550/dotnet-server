using System;
using System.Linq;
using System.Threading;
using GlobalServer.Settings;
using System.Threading.Tasks;
using GlobalServer.Properties;
using Microsoft.Extensions.Hosting;
using GlobalServer.Server.Responses;

namespace GlobalServer.Server
{
    public abstract class ServerBase : IDisposable
    {
        protected IHost Host;
        private CancellationTokenSource _serverToken;
        private readonly IGlobalServerSettings _settings;

        protected ServerBase(IGlobalServerSettings settings)
        {
            Host = null;
            _settings = settings;
        }

        protected abstract ISettingsLoader GetSettingsLoader();
        protected abstract Task StartServer(IServerSettings settings, CancellationToken cancellationToken);

        public async Task<ServerRunResponse> Run()
        {
            if (Host != null)
                return new ServerRunningResponse();

            var validationResult = await new SettingsValidator()
                .ValidateAsync(_settings);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(failure => failure.ErrorMessage);
                return new ValidationErrorServerRunResponse(errors);
            }

            _serverToken = new CancellationTokenSource();
            var serverSettings = await GetSettingsLoader().Load(_settings.FileName);

            await StartServer(serverSettings, _serverToken.Token);
            return new SuccessfulStartResponse();
        }

        public void Dispose()
        {
            _serverToken?.Cancel();
            _serverToken?.Dispose();
            Host?.Dispose();
        }
    }
}