using FluentMigrator;

namespace Migrator.Migrations;

[Migration(202409111)]
public class AddFeedbackTable : Migration
{
    public override void Down()
    {
        Delete.Table("FeatureRequests");
    }

    public override void Up()
    {
        Create.Table("FeatureRequests")
            .WithColumn("Id").AsGuid().PrimaryKey()
            .WithColumn("Text").AsString(1024).NotNullable()
            .WithColumn("Title").AsString(128).NotNullable()
            .WithColumn("Upvotes").AsInt32().WithDefaultValue(0);
        Insert.IntoTable("FeatureRequests")
            .Row(new { Id = Guid.NewGuid(), Text = "FirstOne", Title = "Hi there, hello!" });
    }
}
