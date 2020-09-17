using System.IO.Abstractions.TestingHelpers;
using System.Net.Http;
using System.Threading;
using GlobalServer.Server;
using GlobalServer.Settings;
using System.Threading.Tasks;
using GlobalServer.Properties;
using GlobalServer.Properties.Initialization;
using Configuration = GlobalServer.Api.Configuration;

namespace GlobalServer.Tests.Mocks
{
    public class TestServerImpl : ServerBase
    {
        public MockFileSystemAdapter FileSystem { get; }
        private TestGlobalServer WebFactory { get; set; }

        public TestServerImpl(IGlobalServerSettings settings) : base(settings)
        {
            FileSystem = MockFileSystemAdapter.Create();
        }

        protected override ISettingsLoader GetSettingsLoader()
        {
            var propertiesBuilder = new PropertiesBuilder()
                .WithFileSystem(FileSystem)
                .Build();
            return propertiesBuilder.GetSettingsLoader();
        }

        protected override Task StartServer(ISettings settings, CancellationToken cancellationToken)
        {
            Configuration.Instance.Settings = settings;
            WebFactory = new TestGlobalServer();

            Host = new PlaceholderHost();
            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            base.Dispose();
            WebFactory?.Dispose();
        }

        public HttpClient CreateClient() 
            => WebFactory.CreateClient();

        public void AddFile(string fileName, string fileContents) 
            => FileSystem.AddFile(fileName, new MockFileData(fileContents));
    }
}