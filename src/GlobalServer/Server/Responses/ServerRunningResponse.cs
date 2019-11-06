using GlobalServer.Server.Visitors;

namespace GlobalServer.Server.Responses
{
    public class ServerRunningResponse : ServerRunResponse
    {
        public override bool Success => false;
        public readonly string Error = "Server is all ready running";

        public override T Accept<T>(RunResponseVisitor<T> visitor)
        {
            return visitor.VisitServerRunningResponse(this);
        }
    }
}