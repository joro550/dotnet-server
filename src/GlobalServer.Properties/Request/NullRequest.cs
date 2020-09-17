using GlobalServer.Properties.Request.Queries;

namespace GlobalServer.Properties.Request
{
    public class NullRequest : RequestBase
    {
        public override void Accept(QueryVisitor queryVisitor) 
            => queryVisitor.VisitNullDescription();
    }
}