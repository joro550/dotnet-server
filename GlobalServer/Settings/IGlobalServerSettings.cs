using Config.Net;

namespace GlobalServer.Settings
{
    public interface IGlobalServerSettings
    {
        [Option(Alias = "f")]
        string FileName { get; }
    }
}