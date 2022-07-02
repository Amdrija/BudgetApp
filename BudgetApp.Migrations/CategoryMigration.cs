using FluentMigrator;

namespace BudgetApp.Migrations
{
    [Migration(202207021025)]
    public class CategoryMigration : Migration
    {
        public override void Up()
        {
            this.Create.Table("Category")
                .WithColumn("Id")
                .AsString()
                .PrimaryKey()
                .WithColumn("Name")
                .AsString()
                .Unique()
                .NotNullable()
                .WithColumn("Color")
                .AsString()
                .NotNullable()
                .WithColumn("UserId")
                .AsString()
                .NotNullable();
        }

        public override void Down()
        {
            this.Delete.Table("Category");
        }
    }
}