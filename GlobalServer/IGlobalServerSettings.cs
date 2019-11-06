using Config.Net;

namespace GlobalServer
{
    public interface IGlobalServerSettings
    {
        [Option(Alias = "f")]
        string FileName { get; }
    }
}