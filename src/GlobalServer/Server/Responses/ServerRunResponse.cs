using GlobalServer.Server.Visitors;

namespace GlobalServer.Server.Responses
{
    public abstract class ServerRunResponse
    {
        public abstract bool Success { get; }

        public abstract T Accept<T>(RunResponseVisitor<T> visitor);
    }
}