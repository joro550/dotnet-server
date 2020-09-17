using GlobalServer.Properties.Request.Queries;

namespace GlobalServer.Properties.Request
{
    public class GetRequest : RequestBase
    {
        public override void Accept(QueryVisitor queryVisitor) 
            => queryVisitor.VisitGetDescription(this);
    }
}