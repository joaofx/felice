namespace Felice.Core
{
    using Logs;

    public class FeliceCore
    {
        private static bool initialized;

        public static string Version
        {
            get
            {
                return typeof(FeliceCore).Assembly.GetName().Version.ToString();
            }
        }

        public static void Initialize(LogConfiguration logConfiguration = null)
        {
            if (initialized == false)
            {
                Log.Initialize();
                Log.Framework.InfoFormat("Felice application started");

                Dependency.Initialize();
                
                initialized = true;
            }
        }
    }
}
