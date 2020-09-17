namespace GlobalServer.Properties.Response.Models
{
    public class HeaderDescription
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public void Deconstruct(out string key, out string value)
        {
            key = Key;
            value = Value;
        }
    }
}