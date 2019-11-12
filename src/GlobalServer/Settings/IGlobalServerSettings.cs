using Config.Net;

namespace GlobalServer.Settings
{
    public interface IGlobalServerSettings
    {
        [Option(Alias = "fileName")]
        string FileName { get; }

        [Option(Alias = "command", DefaultValue = "run-server")]
        string Command { get; }
    }

    public class GlobalServerSettings : IGlobalServerSettings
    {
        public string FileName { get; set; }
        public string Command { get; set; }
    }
}