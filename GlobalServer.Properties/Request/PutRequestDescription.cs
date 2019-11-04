using GlobalServer.Properties.Request.Queries;

namespace GlobalServer.Properties.Request
{
    public class PutRequestDescription : RequestDescription
    {
        internal override string Method => "put";

        public override void Accept(Visitor visitor)
        {
            visitor.VisitPutDescription(this);
        }
    }
}