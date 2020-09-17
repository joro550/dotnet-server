namespace GlobalServer.Tests.Files
{
    public static class FileNames
    {
        public static class Requests
        {
            public const string OneGetRequest = "Methods.OneGetRequest";
            public const string OnePostRequest = "Methods.OnePostRequest";
            public const string OnePutRequest = "Methods.OnePutRequest";
            public const string OneDeleteRequest = "Methods.OneDeleteRequest";
            public const string OneHeadRequest = "Methods.OneHeadRequest";
            public const string OneUnknownRequest = "Methods.OneUnknownRequest";
        }

        public static class Ports
        {
            public const string SslEnabled = "Ports.SslEnabled";
            public const string SslDisabled = "Ports.SslDisabled";
            public const string MultipleEndpoints = "Ports.MultipleEndpoints";
        }

        public static class Responses
        {
            public const string ResponseFromFile = "Responses.FromFile";
            public const string ResponseFromString = "Responses.FromString";
            public const string IncrementalListResponse = "Responses.IncrementalList";
            public const string RandomListResponse = "Responses.RandomList";
            public const string BasicResponse = "Responses.Response";
        }
    }
}