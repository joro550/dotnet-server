using System;
using Xunit;
using System.Net;
using System.Net.Http;
using System.Threading;
using GlobalServer.Settings;
using System.Threading.Tasks;
using GlobalServer.Properties;
using GlobalServer.Properties.Initialization;
using GlobalServer.Server;
using GlobalServer.Tests.Files;
using GlobalServer.Tests.Mocks;

namespace GlobalServer.Tests
{
    public class PortTests
    {
        [Fact]
        public async Task ServerRespondsOnConfiguredSecurePort()
        {
            const string file = FileNames.SslEnabled;
            var settings = new GlobalServerSettings { FileName = file };

            using var server = new HelpServerImpl(settings);
            server.FileSystem.AddFile(file, FileLoader.GetFileContents(file));
            await server.Run();

            using var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:5000")
            };

            var result = await client.GetAsync("/things/1234");
            var resultString = await result.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("{\"Hello\":\"World\"}", resultString);
        }

        [Fact]
        public async Task ServerRespondsOnConfiguredPort()
        {
            const string file = FileNames.SslDisabled;
            var settings = new GlobalServerSettings { FileName = file };

            using var server = new HelpServerImpl(settings);
            server.FileSystem.AddFile(file, FileLoader.GetFileContents(file));
            await server.Run();

            using var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5000")
            };

            var result = await client.GetAsync("/things/1234");
            var resultString = await result.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("{\"Hello\":\"World\"}", resultString);
        }
    }

    public class HelpServerImpl : ServerImpl
    {
        public MockFileSystemAdapter FileSystem { get; }
        public TestGlobalServer WebFactory { get; private set; }

        public HelpServerImpl(IGlobalServerSettings settings) : base(settings)
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
    }
}