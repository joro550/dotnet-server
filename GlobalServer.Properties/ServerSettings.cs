using System.Collections.Generic;

namespace GlobalServer.Properties
{
    public interface IServerSettings
    {
        bool TlsEnabled { get; }
        bool SslEnabled { get; }
        List<ServerInteraction> Interactions { get; }
    }

    internal class ServerSettings : IServerSettings
    {
        public bool TlsEnabled { get; set; }
        public bool SslEnabled { get; set; }
        public List<ServerInteraction> Interactions { get; set; }
    }
}