using System.Threading;
using GlobalServer.Api;
using GlobalServer.Settings;
using System.Threading.Tasks;
using GlobalServer.Properties;
using GlobalServer.Properties.Initialization;
using Microsoft.Extensions.Hosting;

namespace GlobalServer.Server
{
    public class ServerImpl : ServerBase
    {
        public ServerImpl(IGlobalServerSettings settings) 
            : base(settings)
        {
        }

        protected override ISettingsLoader GetSettingsLoader() 
            => PropertiesBuilder.Default().GetSettingsLoader();

        protected override Task StartServer(ISettings settings, CancellationToken cancellationToken)
        {
            GlobalServerApi.SetSettings(settings);

            Host = GlobalServerApi.CreateHostBuilder(new string[0])
                .Build();

            return Host.RunAsync(cancellationToken);
        }
    }
}