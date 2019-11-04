using System.IO.Abstractions;

namespace GlobalServer.Properties.Initialization
{
    internal class Configuration
    {
        public static Configuration Instance { get; set; }

        public IFileSystem FileSystem { get; set; }
    }
}