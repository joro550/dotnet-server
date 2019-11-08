using GlobalServer.Properties.Request.Queries;

namespace GlobalServer.Properties.Request
{
    public class NullRequest : RequestBase
    {
        internal override string Method { get; }

        public override void Accept(Visitor visitor)
        {
            visitor.VisitNullDescription(this);
        }
    }
}