namespace GlobalServer.Properties.Request.Queries
{
    public abstract class Visitor
    {
        public abstract void VisitGetDescription(GetRequestDescription element);
        public abstract void VisitDeleteDescription(DeleteRequestDescription element);
        public abstract void VisitPostDescription(PostRequestDescription element);
        public abstract void VisitPutDescription(PutRequestDescription element);
        public abstract void VisitNullDescription(NullRequestDescription element);
    }
}