namespace WebDemo.Boot
{
    using Felice.Data;
    using Maps;
    using Migrations;

    public class DatabaseBoot : IConfigurationBoot
    {
        public void Execute()
        {
            Database.AddMappings(typeof(ProductMap).Assembly);
            Database.AddMigrations(typeof(CreateProduct).Assembly);
        }
    }
}