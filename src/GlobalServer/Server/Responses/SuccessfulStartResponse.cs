using GlobalServer.Server.Visitors;

namespace GlobalServer.Server.Responses
{
    public class SuccessfulStartResponse : ServerRunResponse
    {
        public override bool Success => true;

        public override T Accept<T>(RunResponseVisitor<T> visitor) 
            => visitor.VisitSuccessfulStartResponse(this);
    }
}