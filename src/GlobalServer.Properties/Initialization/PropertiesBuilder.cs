using System.IO.Abstractions;

namespace GlobalServer.Properties.Initialization
{
    public class PropertiesBuilder
    {
        private IFileSystem _fileSystem;

        public PropertiesBuilder WithFileSystem(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
            return this;
        }

        public IPropertiesFactory Build()
        {
            Configuration.Instance = new Configuration
            {
                FileSystem =  _fileSystem ?? new FileSystem() 
            };

            return new PropertiesFactory();
        }

        public static IPropertiesFactory Default() =>
            new PropertiesBuilder().Build();
    }
}