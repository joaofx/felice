namespace Felice.Core
{
    public class BootRunner
    {
        public static void Run()
        {
            var configurationBoot = Dependency.GetAll<IDatabaseRegistry>();

            foreach (var boot in configurationBoot)
            {
                ////boot.Execute();
            }
        }
    }
}
