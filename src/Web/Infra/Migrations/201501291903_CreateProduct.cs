namespace Web.Infra.Migrations
{
    using FluentMigrator;

    [Migration(201501291903)]
    public class CreateProduct : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("Product")
                .WithColumn("Id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("Name").AsString(64).Nullable()
                .WithColumn("Price").AsDecimal().Nullable();
        }
    }
}