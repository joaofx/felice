namespace WebDemo
{
    using Felice.Core;
    using Felice.Data;
    using Maps;
    using Migrations;
    using StructureMap.Graph;

    public class Boot : BootAssemblyOfClass<Boot>
    {
        public override void Execute(IAssemblyScanner scan)
        {
            Database.AddMappings(typeof(ProductMap).Assembly);
            Database.AddMigrations(typeof(CreateProduct).Assembly);
        }
    }
}
