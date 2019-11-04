using System.Collections.Generic;

namespace GlobalServer.Properties
{
    public class ServerSettings
    {
        public bool TlsEnabled { get; set; }
        public bool SslEnabled { get; set; }
        public List<ServerInteraction> Interactions { get; set; }
    }
}