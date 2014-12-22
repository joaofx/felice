namespace Demo.Tests
{
    using Felice.Core;
    using Felice.Data;
    using Felice.TestFramework;
    using NHibernate;

    public class DatabaseCleaner : IDatabaseCleaner
    {
        public void Execute()
        {
            ////Dependency.Resolve<ISession>().DeleteAll<Product>();
        }
    }
}
