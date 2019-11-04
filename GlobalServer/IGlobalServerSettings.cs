using Config.Net;

namespace GlobalServer
{
    public interface IGlobalServerSettings
    {
        [Option(Alias = "fileName")]
        string FileName { get; }
    }
}