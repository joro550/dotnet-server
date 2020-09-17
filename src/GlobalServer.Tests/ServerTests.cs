using Xunit;
using System.Net;
using System.Net.Http;
using GlobalServer.Settings;
using System.Threading.Tasks;
using GlobalServer.Tests.Mocks;
using GlobalServer.Server.Responses;
using static GlobalServer.Tests.Files.FileNames;
using static GlobalServer.Tests.Files.FileLoader;

namespace GlobalServer.Tests
{
    public class ServerTests
    {
        [Fact]
        public async Task ServerRespondsToConfiguredGetRequest()
        {
            var server = await SetupServer(OneGetRequest);
            using var client = server.WebFactory.CreateClient();

            var result = await client.GetAsync("/things/1234");
            var resultString = await result.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("{\"Hello\":\"World\"}", resultString);
        }

        [Fact]
        public async Task ServerRespondsToConfiguredPostRequest()
        {
            var server = await SetupServer(OnePostRequest);
            using var client = server.WebFactory.CreateClient();

            var result = await client.PostAsync("/things/1234", new StringContent(string.Empty));
            var resultString = await result.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("{}", resultString);
        }
        
        [Fact]
        public async Task ServerRespondsToConfiguredPutRequest()
        {
            var server = await SetupServer(OnePutRequest);
            using var client = server.WebFactory.CreateClient();

            var result = await client.PutAsync("/things/1234", new StringContent(string.Empty));
            var resultString = await result.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("{}", resultString);
        }

        [Fact]
        public async Task ServerRespondsToConfiguredDeleteRequest()
        {
            var server = await SetupServer(OneDeleteRequest);
            using var client = server.WebFactory.CreateClient();

            var result = await client.DeleteAsync("/things/1234");
            var resultString = await result.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("{}", resultString);
        }

        public class InvalidRunResponseGetsReturned
        {
            [Fact]
            public async Task WhenAServerGetsMoreThanOneRunRequest()
            {
                var server = await SetupServer(OneDeleteRequest);
                var runResponse = await server.Run();
                    
                Assert.False(runResponse.Success);
                var serverRunningResponse = Assert.IsType<ServerRunningResponse>(runResponse);
                Assert.Equal("Server is all ready running", serverRunningResponse.Error);
            }

            [Fact]
            public async Task WhenNoFileNameHasBeenSpecified()
            {
                using var server = new TestServerImpl(new GlobalServerSettings {FileName = string.Empty});

                var runResponse = await server.Run();
                Assert.False(runResponse.Success);
                var serverRunningResponse = Assert.IsType<ValidationErrorServerRunResponse>(runResponse);
                Assert.Contains("No filename was specified, please specify a file i.e. dotnet-server -fileName:C:\\file.txt", serverRunningResponse.ValidationErrors);
            }
        }

        private static async Task<TestServerImpl> SetupServer(string configFileName)
        {
            var settings = new GlobalServerSettings {FileName = configFileName};

            using var server = new TestServerImpl(settings);
            server.FileSystem.AddFile(configFileName, GetFileContents(configFileName));
            await server.Run();
            return server;
        }
    }
}