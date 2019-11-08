using GlobalServer.Properties.Request.Queries;

namespace GlobalServer.Properties.Request
{
    public class GetRequest : RequestBase
    {
        internal override string Method => "get";
        public override void Accept(Visitor visitor)
        {
            visitor.VisitGetDescription(this);
        }
    }
}