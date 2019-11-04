using GlobalServer.Properties.Request.Queries;

namespace GlobalServer.Properties.Request
{
    public class GetRequestDescription : RequestDescription
    {
        internal override string Method => "get";
        public override void Accept(Visitor visitor)
        {
            visitor.VisitGetDescription(this);
        }
    }
}