namespace Demo.Migrations
{
    using FluentMigrator;

    [Migration(201412171809)]
    public class CreateProject : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("projects")
                .WithColumn("id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("name").AsString(64).Nullable();
        }
    }
}