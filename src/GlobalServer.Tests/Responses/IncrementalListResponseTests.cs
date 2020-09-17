using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GlobalServer.Tests.Files;
using Xunit;

namespace GlobalServer.Tests.Responses
{
    public class IncrementalListResponseTests : ServerTestBase
    {
        [Fact]
        public async Task ServerRespondsToConfiguredGetRequest()
        {
            var server = await SetupServer(FileNames.Responses.IncrementalListResponse);
            using var client = server.CreateClient();

            var firstResult = await client.GetAsync("/things/1234");
            var firstResultString = await firstResult.Content.ReadAsStringAsync();
            
            var secondResult = await client.GetAsync("/things/1234");
            var secondResultString = await secondResult.Content.ReadAsStringAsync();
            
            var thirdResult = await client.GetAsync("/things/1234");
            var thirdResultString = await thirdResult.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.OK, firstResult.StatusCode);
            Assert.Equal("{\"Key1\":\"Value1\"}", firstResultString);
            
            Assert.Equal(HttpStatusCode.OK, secondResult.StatusCode);
            Assert.Equal("{\"Key2\":\"Value2\"}", secondResultString);
            
            Assert.Equal(HttpStatusCode.OK, thirdResult.StatusCode);
            Assert.Equal("{\"Key1\":\"Value1\"}", thirdResultString);
        }
        
        [Fact]
        public async Task ServerRespondsToConfiguredPostRequest()
        {
            var server = await SetupServer(FileNames.Responses.IncrementalListResponse);
            using var client = server.CreateClient();

            var firstResult = await client.PostAsync("/things/1234", new StringContent(string.Empty));
            var firstResultString = await firstResult.Content.ReadAsStringAsync();
            
            var secondResult = await client.PostAsync("/things/1234", new StringContent(string.Empty));
            var secondResultString = await secondResult.Content.ReadAsStringAsync();
            
            var thirdResult = await client.PostAsync("/things/1234", new StringContent(string.Empty));
            var thirdResultString = await thirdResult.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.OK, firstResult.StatusCode);
            Assert.Equal("{\"Key1\":\"Value1\"}", firstResultString);
            
            Assert.Equal(HttpStatusCode.OK, secondResult.StatusCode);
            Assert.Equal("{\"Key2\":\"Value2\"}", secondResultString);
            
            Assert.Equal(HttpStatusCode.OK, thirdResult.StatusCode);
            Assert.Equal("{\"Key1\":\"Value1\"}", thirdResultString);
        }
        
        [Fact]
        public async Task ServerRespondsToConfiguredPutRequest()
        {
            var server = await SetupServer(FileNames.Responses.IncrementalListResponse);
            using var client = server.CreateClient();

            var firstResult = await client.PutAsync("/things/1234", new StringContent(string.Empty));
            var firstResultString = await firstResult.Content.ReadAsStringAsync();
            
            var secondResult = await client.PutAsync("/things/1234", new StringContent(string.Empty));
            var secondResultString = await secondResult.Content.ReadAsStringAsync();
            
            var thirdResult = await client.PutAsync("/things/1234", new StringContent(string.Empty));
            var thirdResultString = await thirdResult.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.OK, firstResult.StatusCode);
            Assert.Equal("{\"Key1\":\"Value1\"}", firstResultString);
            
            Assert.Equal(HttpStatusCode.OK, secondResult.StatusCode);
            Assert.Equal("{\"Key2\":\"Value2\"}", secondResultString);
            
            Assert.Equal(HttpStatusCode.OK, thirdResult.StatusCode);
            Assert.Equal("{\"Key1\":\"Value1\"}", thirdResultString);
        }
        
        [Fact]
        public async Task ServerRespondsToConfiguredDeleteRequest()
        {
            var server = await SetupServer(FileNames.Responses.IncrementalListResponse);
            using var client = server.CreateClient();

            var firstResult = await client.DeleteAsync("/things/1234");
            var firstResultString = await firstResult.Content.ReadAsStringAsync();
            
            var secondResult = await client.DeleteAsync("/things/1234");
            var secondResultString = await secondResult.Content.ReadAsStringAsync();
            
            var thirdResult = await client.DeleteAsync("/things/1234");
            var thirdResultString = await thirdResult.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.OK, firstResult.StatusCode);
            Assert.Equal("{\"Key1\":\"Value1\"}", firstResultString);
            
            Assert.Equal(HttpStatusCode.OK, secondResult.StatusCode);
            Assert.Equal("{\"Key2\":\"Value2\"}", secondResultString);
            
            Assert.Equal(HttpStatusCode.OK, thirdResult.StatusCode);
            Assert.Equal("{\"Key1\":\"Value1\"}", thirdResultString);
        }
        
        [Fact]
        public async Task ServerRespondsToConfiguredHeadRequest()
        {
            var server = await SetupServer(FileNames.Responses.IncrementalListResponse);
            using var client = server.CreateClient();

            var firstMessage = new HttpRequestMessage(HttpMethod.Head, "/things/1234");
            
            var firstResult = await client.SendAsync(firstMessage);
            var firstResultString = await firstResult.Content.ReadAsStringAsync();
            
            var secondMessage = new HttpRequestMessage(HttpMethod.Head, "/things/1234");
            var secondResult = await client.SendAsync(secondMessage);
            var secondResultString = await secondResult.Content.ReadAsStringAsync();
            
            var thirdMessage = new HttpRequestMessage(HttpMethod.Head, "/things/1234");
            var thirdResult = await client.SendAsync(thirdMessage);
            var thirdResultString = await thirdResult.Content.ReadAsStringAsync();
            
            Assert.Equal(HttpStatusCode.OK, firstResult.StatusCode);
            Assert.Equal("{\"Key1\":\"Value1\"}", firstResultString);
            
            Assert.Equal(HttpStatusCode.OK, secondResult.StatusCode);
            Assert.Equal("{\"Key2\":\"Value2\"}", secondResultString);
            
            Assert.Equal(HttpStatusCode.OK, thirdResult.StatusCode);
            Assert.Equal("{\"Key1\":\"Value1\"}", thirdResultString);
        }
    }
}