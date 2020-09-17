using GlobalServer.Server.Responses;

namespace GlobalServer.Server.Visitors
{
    public abstract class RunResponseVisitor<T>
    {
        public abstract T VisitValidationErrorResponse(ValidationErrorServerRunResponse response);
        public abstract T VisitServerRunningResponse(ServerRunningResponse response);
        public abstract T VisitSuccessfulStartResponse();
    }
}