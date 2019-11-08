using Xunit;
using System.Net;
using System.Net.Http;
using GlobalServer.Settings;
using System.Threading.Tasks;
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

            using var server = new TestRealServerImpl(settings);
            server.FileSystem.AddFile(file, FileLoader.GetFileContents(file));
            await server.Run();

            using var client = new HttpClient();

            var result = await client.GetAsync("https://localhost:5000/things/1234");
            var resultString = await result.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("{\"Hello\":\"World\"}", resultString);
        }

        [Fact]
        public async Task ServerRespondsOnConfiguredPort()
        {
            const string file = FileNames.SslDisabled;
            var settings = new GlobalServerSettings { FileName = file };

            using var server = new TestRealServerImpl(settings);
            server.FileSystem.AddFile(file, FileLoader.GetFileContents(file));
            await server.Run();

            using var client = new HttpClient();

            var result = await client.GetAsync("http://localhost:5000/things/1234");
            var resultString = await result.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("{\"Hello\":\"World\"}", resultString);
        }

        [Fact]
        public async Task ServerRespondsOnMultipleConfiguredPort()
        {
            const string file = FileNames.MultipleEndpoints;
            var settings = new GlobalServerSettings { FileName = file };

            using var server = new TestRealServerImpl(settings);
            server.FileSystem.AddFile(file, FileLoader.GetFileContents(file));
            await server.Run();

            using var client = new HttpClient();

            var result1 = await client.GetAsync("http://localhost:5000/things/1234");
            var result2 = await client.GetAsync("http://localhost:5001/things/1234");
            var result3 = await client.GetAsync("https://localhost:5002/things/1234");
            var result4 = await client.GetAsync("https://localhost:5003/things/1234");
            
            await TestResult(result1);
            await TestResult(result2);
            await TestResult(result3);
            await TestResult(result4);
        }

        private static async Task TestResult(HttpResponseMessage result)
        {
            var resultString = await result.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("{\"Hello\":\"World\"}", resultString);
        }
    }
}