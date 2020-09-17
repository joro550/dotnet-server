using System.IO;
using GlobalServer.Properties.Initialization;
using GlobalServer.Properties.Response.Models;
using Newtonsoft.Json;

namespace GlobalServer.Properties.Response
{
    public class ResponseFromFile : SingleResponseBase
    {
        [JsonProperty("fileName")]
        public string FileName { get; set; }
        
        protected override string GetResponse()
        {
            using var streamReader = new StreamReader(
                Configuration.Instance.FileSystem.File.OpenRead(FileName));
            return streamReader.ReadToEnd();
        }
    }
}