using Xunit;
using System.Net;
using System.Net.Http;
using GlobalServer.Settings;
using System.Threading.Tasks;
using GlobalServer.Tests.Files;
using GlobalServer.Tests.Mocks;

namespace GlobalServer.Tests
{
    public class ServerTests
    {
        [Fact]
        public async Task ServerRespondsToConfiguredGetRequest()
        {
            const string file = FileNames.OneGetRequest;
            var settings = new GlobalServerSettings{FileName = file};

            using var server = new TestServerImpl(settings);
            server.FileSystem.AddFile(file, FileLoader.GetFileContents(file));
            await server.Run();

            using var client = server.WebFactory.CreateClient();

            var result = await client.GetAsync("/things/1234");
            var resultString = await result.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("{\"Hello\":\"World\"}", resultString);
        }

        [Fact]
        public async Task ServerRespondsToConfiguredPostRequest()
        {
            const string file = FileNames.OnePostRequest;
            var settings = new GlobalServerSettings{FileName = file};

            using var server = new TestServerImpl(settings);
            server.FileSystem.AddFile(file, FileLoader.GetFileContents(file));
            await server.Run();

            using var client = server.WebFactory.CreateClient();

            var result = await client.PostAsync("/things/1234", new StringContent(string.Empty));
            var resultString = await result.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("{}", resultString);
        }
        
        [Fact]
        public async Task ServerRespondsToConfiguredPutRequest()
        {
            const string file = FileNames.OnePutRequest;
            var settings = new GlobalServerSettings{FileName = file};

            using var server = new TestServerImpl(settings);
            server.FileSystem.AddFile(file, FileLoader.GetFileContents(file));
            await server.Run();

            using var client = server.WebFactory.CreateClient();

            var result = await client.PutAsync("/things/1234", new StringContent(string.Empty));
            var resultString = await result.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("{}", resultString);
        }
        
        [Fact]
        public async Task ServerRespondsToConfiguredDeleteRequest()
        {
            const string file = FileNames.OneDeleteRequest;
            var settings = new GlobalServerSettings{FileName = file};

            using var server = new TestServerImpl(settings);
            server.FileSystem.AddFile(file, FileLoader.GetFileContents(file));
            await server.Run();

            using var client = server.WebFactory.CreateClient();

            var result = await client.DeleteAsync("/things/1234");
            var resultString = await result.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("{}", resultString);
        }
    }
}