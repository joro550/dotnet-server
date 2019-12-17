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
        [InlineData(OneGetRequest, typeof(GetRequest))]
        [InlineData(OnePutRequest, typeof(PutRequest))]
        [InlineData(OnePostRequest, typeof(PostRequest))]
        [InlineData(OneUnknownRequest, typeof(NullRequest))]
        [InlineData(OneDeleteRequest, typeof(DeleteRequest))]
        public void GivenFileWithSpecifiedRequest_ThenRequestDescriptionIsCorrectType(string fileName, Type requestType)
        {
            var settings = LoadSettings(fileName);

            var interaction = Assert.Single(settings.Result.Interactions);
            Assert.NotNull(interaction);

            Assert.IsType(requestType, interaction.Request);
        }

        [Theory]
        [InlineData(RandomListResponse, typeof(RandomFromListResponse))]
        [InlineData(FileNames.ResponseFromFile, typeof(ResponseFromFile))]
        [InlineData(FileNames.ResponseFromString, typeof(ResponseFromString))]
        [InlineData(FileNames.IncrementalListResponse, typeof(IncrementalListResponse))]
        public void EachResponseCanBeLoadedFromConfig(string fileName, Type expectedType)
        {
            var settings = FileLoader.LoadSettings(fileName);
            Assert.IsType(expectedType, settings.Result.Interactions[0].Response);
        }
    }
}
