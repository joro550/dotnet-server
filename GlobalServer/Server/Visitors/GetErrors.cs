using System.Collections.Generic;
using System.Linq;
using GlobalServer.Server.Responses;

namespace GlobalServer.Server.Visitors
{
    public class GetErrors : RunResponseVisitor<List<string>>
    {
        public override List<string> VisitValidationErrorResponse(ValidationErrorServerRunResponse response) 
            => response.ValidationErrors.ToList();

        public override List<string> VisitServerRunningResponse(ServerRunningResponse response) 
            => new List<string> {response.Error};

        public override List<string> VisitSuccessfulStartResponse(SuccessfulStartResponse response) 
            => new List<string>();
    }
}