using GlobalServer.Properties.Request.Queries;

namespace GlobalServer.Properties.Request
{
    public class PutRequest : RequestBase
    {
        public override void Accept(QueryVisitor queryVisitor) 
            => queryVisitor.VisitPutDescription(this);
    }
}