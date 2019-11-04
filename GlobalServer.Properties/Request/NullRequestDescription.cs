using GlobalServer.Properties.Request.Queries;

namespace GlobalServer.Properties.Request
{
    public class NullRequestDescription : RequestDescription
    {
        internal override string Method { get; }

        public override void Accept(Visitor visitor)
        {
            visitor.VisitNullDescription(this);
        }
    }
}