using System.IO;
using System.Reflection;

namespace GlobalServer.Tests.Files
{
    public class FileLoader
    {
        public static string GetFileContents(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"GlobalServer.Tests.Files.{fileName}.json";

            using var stream = assembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}