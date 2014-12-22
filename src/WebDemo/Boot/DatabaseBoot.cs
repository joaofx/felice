namespace WebDemo.Boot
{
    using Felice.Data;
    using Maps;
    using Migrations;

    public class DatabaseBoot : IConfigurationBoot
    {
        public void Execute()
        {
            Database.Configuration.AddMapping(typeof(ProductMap).Assembly);
            Database.Configuration.AddMigration(typeof(CreateProduct).Assembly);
        }
    }
}