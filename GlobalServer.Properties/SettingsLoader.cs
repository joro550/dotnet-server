using Newtonsoft.Json;
using System.IO.Abstractions;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using GlobalServer.Properties.Initialization;

[assembly:InternalsVisibleTo("GlobalServer.Tests")]

namespace GlobalServer.Properties
{
    public interface ISettingsLoader
    {
        Task<IServerSettings> Load(string file);
    }

    internal class SettingsLoader : ISettingsLoader
    {
        private readonly IFileSystem _fileSystem;

        public SettingsLoader()
        {
            _fileSystem = Configuration.Instance.FileSystem;
        }

        public async Task<IServerSettings> Load(string file)
        {
            using (var s = _fileSystem.File.OpenText(file))
            {
                var settings = await s.ReadToEndAsync();
                return JsonConvert.DeserializeObject<ServerSettings>(settings);
            }
        }
    }
}