namespace Felice.Core
{
    using System.Configuration;

    public static class SettingsConfig
    {
        public static string DatabaseConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["Database.ConnectionString"];
            }
        }
    }
}
