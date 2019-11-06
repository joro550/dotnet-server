using System.Collections.Generic;
using GlobalServer.Server.Visitors;

namespace GlobalServer.Server.Responses
{
    public class ValidationErrorServerRunResponse : ServerRunResponse
    {
        public override bool Success => false;
        public IEnumerable<string> ValidationErrors { get; }

        public ValidationErrorServerRunResponse(IEnumerable<string> validationErrors)
        {
            ValidationErrors = validationErrors;
        }

        public override T Accept<T>(RunResponseVisitor<T> visitor)
        {
            return visitor.VisitValidationErrorResponse(this);
        }
    }
}