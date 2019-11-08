using Xunit;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using GlobalServer.Properties.Initialization;

namespace GlobalServer.Tests
{
    public class PropertiesBuilderTests
    {
        [Fact]
        public void WhenDefaultPropertiesFactoryGetsBuilt_ThenFileSystemIsReal()
        {
            PropertiesBuilder.Default();
            Assert.IsType<FileSystem>(Configuration.Instance.FileSystem);
        }

        [Fact]
        public void WhenFileSystemIsSpecified_ThenFileSystemIsTheOneSpecified()
        {
            new PropertiesBuilder().WithFileSystem(new MockFileSystem()).Build();
            Assert.IsType<MockFileSystem>(Configuration.Instance.FileSystem);
        }
    }
}