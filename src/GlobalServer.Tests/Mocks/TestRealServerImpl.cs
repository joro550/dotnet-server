using System.Threading;
using System.Threading.Tasks;
using GlobalServer.Server;
using GlobalServer.Settings;
using GlobalServer.Properties;
using GlobalServer.Properties.Initialization;

namespace GlobalServer.Tests.Mocks
{
    public class TestRealServerImpl : ServerImpl
    {
        public MockFileSystemAdapter FileSystem { get; }

        public TestRealServerImpl(IGlobalServerSettings settings) : base(settings)
        {
            FileSystem = MockFileSystemAdapter.Create();
        }

        protected override Task StartServer(ISettings settings, CancellationToken cancellationToken)
        {
            base.StartServer(settings, cancellationToken);
            return Task.CompletedTask;
        }

        protected override ISettingsLoader GetSettingsLoader()
        {
            var propertiesBuilder = new PropertiesBuilder()
                .WithFileSystem(FileSystem)
                .Build();
            return propertiesBuilder.GetSettingsLoader();
        }
    }
}