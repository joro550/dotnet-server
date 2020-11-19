using System.Threading.Tasks;
using GlobalServer.Properties.Request.Converters;
using Newtonsoft.Json;

namespace GlobalServer.Properties.Request.Actions
{
    public abstract class ActionBase
    {
        [JsonConverter(typeof(ActionConverter))]
        public string Type { get; set; }

        public abstract Task Perform();
    }
}