namespace Demo.Tests
{
    using Felice.Data;
    using Felice.TestFramework;
    using WebDemo.Models;

    public class DatabaseCleaner : DaoBase, IDatabaseCleaner
    {
        public void Execute()
        {
            Session.DeleteAll<Product>();
        }
    }
}
