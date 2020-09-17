namespace GlobalServer.Properties.Request.Queries
{
    public abstract class QueryVisitor
    {
        public abstract void VisitGetDescription(GetRequest element);
        public abstract void VisitDeleteDescription(DeleteRequest element);
        public abstract void VisitPostDescription(PostRequest element);
        public abstract void VisitPutDescription(PutRequest element);
        public abstract void VisitHeadDescription(HeadRequest element);
        public abstract void VisitOptionsDescription(OptionsRequest element);
        public abstract void VisitNullDescription();
    }
}