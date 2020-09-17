using Xunit;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GlobalServer.Tests.Files;

namespace GlobalServer.Tests.Responses
{
    public class FromFileResponseTests : ServerTestBase
    {
        [Fact]
        public async Task ServerRespondsToConfiguredGetRequest()
        {
            var server = await SetupServer(FileNames.Responses.ResponseFromFile);
            server.AddFile("response.txt", "{\"Hello\", \"World\"}");
            
            using var client = server.CreateClient();

            var result = await client.GetAsync("/things/1234");
            var resultString = await result.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("{\"Hello\", \"World\"}", resultString);
        }
        
        [Fact]
        public async Task ServerRespondsToConfiguredPostRequest()
        {
            var server = await SetupServer(FileNames.Responses.ResponseFromFile);
            server.AddFile("response.txt", "{\"Hello\", \"World\"}");
            using var client = server.CreateClient();

            var result = await client.PostAsync("/things/1234", new StringContent(string.Empty));
            var resultString = await result.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("{\"Hello\", \"World\"}", resultString);
        }
        
        [Fact]
        public async Task ServerRespondsToConfiguredPutRequest()
        {
            var server = await SetupServer(FileNames.Responses.ResponseFromFile);
            server.AddFile("response.txt", "{\"Hello\", \"World\"}");
            using var client = server.CreateClient();

            var result = await client.PutAsync("/things/1234", new StringContent(string.Empty));
            var resultString = await result.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("{\"Hello\", \"World\"}", resultString);
        }
        
        [Fact]
        public async Task ServerRespondsToConfiguredDeleteRequest()
        {
            var server = await SetupServer(FileNames.Responses.ResponseFromFile);
            server.AddFile("response.txt", "{\"Hello\", \"World\"}");
            using var client = server.CreateClient();

            var result = await client.DeleteAsync("/things/1234");
            var resultString = await result.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("{\"Hello\", \"World\"}", resultString);
        }
        
        [Fact]
        public async Task ServerRespondsToConfiguredHeadRequest()
        {
            var server = await SetupServer(FileNames.Responses.ResponseFromFile);
            server.AddFile("response.txt", "{\"Hello\", \"World\"}");
            using var client = server.CreateClient();

            var message = new HttpRequestMessage(HttpMethod.Head, "/things/1234");
            var result = await client.SendAsync(message);
            var resultString = await result.Content.ReadAsStringAsync();

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("{\"Hello\", \"World\"}", resultString);
        }
    }
}