using GlobalServer.Properties.Request.Queries;

namespace GlobalServer.Properties.Request
{
    public class PostRequest : RequestBase
    {
        public override void Accept(QueryVisitor queryVisitor) 
            => queryVisitor.VisitPostDescription(this);
    }
}