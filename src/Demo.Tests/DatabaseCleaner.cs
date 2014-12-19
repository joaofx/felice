namespace Demo.Tests
{
    using Felice.Core;
    using Felice.Data;
    using Felice.TestFramework;
    using NHibernate;
    using WebDemo.Models;

    public class DatabaseCleaner : IDatabaseCleaner
    {
        public void Execute()
        {
            Dependency.Resolve<ISession>().DeleteAll<Product>();
        }
    }
}
