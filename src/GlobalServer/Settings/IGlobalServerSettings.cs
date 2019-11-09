using Config.Net;

namespace GlobalServer.Settings
{
    public interface IGlobalServerSettings
    {
        [Option(Alias = "fileName")]
        string FileName { get; }
    }

    public class GlobalServerSettings : IGlobalServerSettings
    {
        public string FileName { get; set; }
    }
}