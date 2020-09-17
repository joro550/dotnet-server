using Xunit;
using System;
using GlobalServer.Tests.Files;
using GlobalServer.Properties.Request;
using GlobalServer.Properties.Response;
using static GlobalServer.Tests.Files.FileNames;
using static GlobalServer.Tests.Files.FileLoader;

namespace GlobalServer.Tests
{
    public class SettingsLoaderTests
    {
        [Theory]
        [InlineData(Requests.OneGetRequest, typeof(GetRequest))]
        [InlineData(Requests.OnePutRequest, typeof(PutRequest))]
        [InlineData(Requests.OnePostRequest, typeof(PostRequest))]
        [InlineData(Requests.OneUnknownRequest, typeof(NullRequest))]
        [InlineData(Requests.OneDeleteRequest, typeof(DeleteRequest))]
        public void GivenFileWithSpecifiedRequest_ThenRequestDescriptionIsCorrectType(string fileName, Type requestType)
        {
            var settings = LoadSettings(fileName);

            var interaction = Assert.Single(settings.Result.Interactions);
            Assert.NotNull(interaction);

            Assert.IsType(requestType, interaction.Request);
        }

        [Theory]
        [InlineData(FileNames.Responses.RandomListResponse, typeof(RandomFromListResponse))]
        [InlineData(FileNames.Responses.ResponseFromFile, typeof(ResponseFromFile))]
        [InlineData(FileNames.Responses.ResponseFromString, typeof(ResponseFromString))]
        [InlineData(FileNames.Responses.IncrementalListResponse, typeof(IncrementalListResponse))]
        public void EachResponseCanBeLoadedFromConfig(string fileName, Type expectedType)
        {
            var settings = FileLoader.LoadSettings(fileName);
            Assert.IsType(expectedType, settings.Result.Interactions[0].Response);
        }
    }
}
