using GlobalServer.Properties.Request.Queries;

namespace GlobalServer.Properties.Request
{
    public class HeadRequest : RequestBase
    {
        public override void Accept(QueryVisitor queryVisitor) 
            => queryVisitor.VisitHeadDescription(this);
    }
}