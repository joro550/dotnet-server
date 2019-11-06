namespace GlobalServer.Properties.Initialization
{
    public interface IPropertiesFactory
    {
        ISettingsLoader GetSettingsLoader();
    }

    internal class PropertiesFactory : IPropertiesFactory
    {
        public ISettingsLoader GetSettingsLoader() 
            => new SettingsLoader();
    }
}