using System.IO.Abstractions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GlobalServer.Properties
{
    public class SettingsLoader
    {
        private readonly IFileSystem _fileSystem;

        public SettingsLoader(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public async Task<ServerSettings> Load(string file)
        {
            using (var s = _fileSystem.File.OpenText(file))
            {
                var settings = await s.ReadToEndAsync();
                return JsonConvert.DeserializeObject<ServerSettings>(settings);
            }
        }
    }
}