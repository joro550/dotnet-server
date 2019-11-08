using GlobalServer.Properties;

namespace GlobalServer.Api
{
    public class Configuration
    {
        public static Configuration Instance { get; } = new Configuration();
        public ISettings Settings { get; set; }
    }
}