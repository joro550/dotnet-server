using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using GlobalServer.Properties;
using GlobalServer.Properties.Initialization;
using static GlobalServer.Tests.Mocks.MockFileSystemAdapter;

namespace GlobalServer.Tests.Files
{
    public static class FileLoader
    {
        public static string GetFileContents(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"GlobalServer.Tests.Files.{fileName}.json";

            using var stream = assembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        public static Task<ISettings> LoadSettings(string fileName)
        {
            const string fileLocation = @"c:\MyFile.txt";
            var fileSystem = Create(fileLocation, GetFileContents(fileName));

            var propertiesBuilder = new PropertiesBuilder()
                .WithFileSystem(fileSystem)
                .Build();

            return propertiesBuilder.GetSettingsLoader().Load(fileLocation);
        }
    }
}