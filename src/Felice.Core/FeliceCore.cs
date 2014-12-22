namespace Felice.Core
{
    using Logs;

    public class FeliceCore : IFeliceInitialization
    {
        private static bool initialized;

        public static string Version
        {
            get
            {
                return typeof(FeliceCore).Assembly.GetName().Version.ToString();
            }
        }

        public static IFeliceInitialization Initialize(LogConfiguration logConfiguration = null)
        {
            if (initialized == false)
            {
                Log.Initialize();
                Log.Framework.InfoFormat("Felice application started");

                ////Dependency.Initialize();

                initialized = true;
            }

            return new FeliceCore();
        }

        public static void Boot()
        {
        }
    }
}
