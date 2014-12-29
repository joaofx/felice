namespace Demo.Migrations
{
    using FluentMigrator;

    [Migration(201412282204)]
    public class CreateFood : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("food")
                .WithColumn("id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("name").AsString(64).Nullable()
                .WithColumn("calories").AsDecimal().Nullable()
                .WithColumn("carbs").AsDecimal().Nullable()
                .WithColumn("fats").AsDecimal().Nullable()
                .WithColumn("proteins").AsDecimal().Nullable();
        }
    }
}