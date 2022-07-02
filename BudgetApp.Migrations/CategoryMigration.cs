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
                .NotNullable()
                .WithColumn("Color")
                .AsString()
                .NotNullable()
                .WithColumn("UserId")
                .AsString()
                .NotNullable();

            this.Create.UniqueConstraint("NameAndUserId")
                .OnTable("Category")
                .Columns("Name", "UserId");
        }

        public override void Down()
        {
            this.Delete.Table("Category");
        }
    }
}