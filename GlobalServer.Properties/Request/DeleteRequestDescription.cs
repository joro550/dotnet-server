using GlobalServer.Properties.Request.Queries;

namespace GlobalServer.Properties.Request
{
    public class DeleteRequestDescription : RequestDescription
    {
        internal override string Method => "delete";
        public override void Accept(Visitor visitor)
        {
            visitor.VisitDeleteDescription(this);
        }
    }
}