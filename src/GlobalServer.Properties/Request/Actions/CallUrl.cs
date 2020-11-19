using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace GlobalServer.Properties.Request.Actions
{
    public class CallUrl : ActionBase
    {
        public string Uri { get; set; }
        public string Method { get; set; }
        public string Body { get; set; }
        public string ContentType { get; set; }


        public override async Task Perform()
        {
            using var httpClient = new HttpClient();
            var message = new HttpRequestMessage(new HttpMethod(Method.ToUpper()), new Uri(Uri));

            if (string.IsNullOrWhiteSpace(Body))
            {
                message.Content = new StringContent(Body, Encoding.UTF8, ContentType);
            }

            await httpClient.SendAsync(message);
        }
    }
}