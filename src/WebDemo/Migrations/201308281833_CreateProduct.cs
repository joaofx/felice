using System;

namespace WebDemo.Migrations
{
    using FluentMigrator;

    [Migration(201308281833)]
    public class CreateProduct : Migration
    {
        public override void Up()
        {
            Create.Table("product")
                .WithColumn("id").AsInt64().NotNullable().PrimaryKey().Identity()
                .WithColumn("name").AsString(64).Nullable()
                .WithColumn("price").AsDecimal().Nullable();
        }

        public override void Down()
        {
            Delete.Table("product");
        }
    }
}