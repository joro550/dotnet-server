using System.Threading;
using System.Threading.Tasks;
using GlobalServer.Api;
using GlobalServer.Properties;
using GlobalServer.Properties.Initialization;
using GlobalServer.Settings;

namespace GlobalServer.Server
{
    public class ServerBaseImpl : ServerBase
    {
        public ServerBaseImpl(IGlobalServerSettings settings) : base(settings)
        {
        }

        protected override ISettingsLoader GetSettingsLoader()
        {
            var propertiesFactory = PropertiesBuilder.Default();
            return propertiesFactory.GetSettingsLoader();
        }

        protected override Task StartServer(IServerSettings settings, CancellationToken cancellationToken)
        {
            Host = GlobalServerApi.CreateHostBuilder(settings).Build();
            return Host.StartAsync(cancellationToken);
        }
    }
}