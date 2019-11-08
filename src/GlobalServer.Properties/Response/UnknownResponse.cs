namespace GlobalServer.Properties.Response
{
    public class UnknownResponse : ResponseBase
    {
        public override string Keyword => string.Empty;

        public override string GetContentType() 
            => string.Empty;

        public override string GetResponse() 
            => string.Empty;
    }
}