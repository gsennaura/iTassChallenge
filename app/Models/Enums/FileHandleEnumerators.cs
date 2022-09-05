namespace Guilherme.SenaGuilherme.Models.Enums
{
    public class FileHandleEnumerators
    {
        public enum SupportedFileTypes 
        {
            MinhaCDN,
            Agora
        }
        public class SourceName
        {
            public const string MyCDN = $"\"Minha CDN\"";
        }

        public class FileFields
        {
            public const string Provider = "provider";
            public const string HttpMethod = "http-method";
            public const string StatusCode = "status-code";
            public const string UriPath = "uri-path";
            public const string TimeTaken = "time-taken";
            public const string ResponseSize = "response-size";
            public const string CacheStatus = "cache-status";
            public const string Protocol = "protocol";
        }

        public class DestinationName
        {
            public const string Current = "Agora";
        }
    
    }
}
