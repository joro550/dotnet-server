using GlobalServer.Properties.Request.Queries;

namespace GlobalServer.Properties.Request
{
    public class PostRequestDescription : RequestDescription
    {
        internal override string Method => "post";
        public override void Accept(Visitor visitor)
        {
            visitor.VisitPostDescription(this);
        }
    }
}