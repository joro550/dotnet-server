using GlobalServer.Properties.Request.Queries;

namespace GlobalServer.Properties.Request
{
    public class OptionsRequest : RequestBase
    {
        public override void Accept(QueryVisitor queryVisitor) 
            => queryVisitor.VisitOptionsDescription(this);
    }
}