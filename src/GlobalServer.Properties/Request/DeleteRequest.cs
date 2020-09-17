using GlobalServer.Properties.Request.Queries;

namespace GlobalServer.Properties.Request
{
    public class DeleteRequest : RequestBase
    {
        public override void Accept(QueryVisitor queryVisitor)
        {
            queryVisitor.VisitDeleteDescription(this);
        }
    }
}