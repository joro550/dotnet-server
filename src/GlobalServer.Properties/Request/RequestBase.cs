using GlobalServer.Properties.Request.Queries;

namespace GlobalServer.Properties.Request
{
    public abstract class RequestBase
    {
        public string Path { get; set; }

        public abstract void Accept(QueryVisitor queryVisitor);
    }
}