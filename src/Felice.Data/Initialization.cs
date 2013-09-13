namespace Felice.Data
{
    using Core;

    public static class Initialization
    {
        public static IFeliceInitialization InitializeDatabase(this IFeliceInitialization init)
        {
            Database.Initialize();
            return init;
        }
    }
}

