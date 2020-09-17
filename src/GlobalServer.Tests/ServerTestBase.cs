using System.Threading.Tasks;
using GlobalServer.Settings;
using GlobalServer.Tests.Files;
using GlobalServer.Tests.Mocks;

namespace GlobalServer.Tests
{
    public class ServerTestBase
    {
        protected static async Task<TestServerImpl> SetupServer(string configFileName)
        {
            var settings = new GlobalServerSettings {FileName = configFileName};
            using var server = new TestServerImpl(settings);
            server.FileSystem.AddFile(configFileName, FileLoader.GetFileContents(configFileName));
            await server.Run();
            return server;
        }
    }
}