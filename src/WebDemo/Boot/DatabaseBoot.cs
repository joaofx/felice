namespace WebDemo.Boot
{
    using Felice.Data;
    using Maps;
    using Migrations;

    public class DatabaseBoot : IConfigurationBoot
    {
        public void Execute()
        {
            Database.Configuration.AddMappings(typeof(ProductMap).Assembly);
            Database.Configuration.AddMigrations(typeof(CreateProduct).Assembly);
        }
    }
}