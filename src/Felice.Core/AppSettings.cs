namespace Felice.Core
{
    using System.Configuration;

    public static class AppSettings
    {
        public static string ConnectionString
        {
            get
            {
                var config = ConfigurationManager.ConnectionStrings["App"];

                if (config != null)
                {
                    return config.ConnectionString;
                }

                return string.Empty;
            }
        }
    }
}
