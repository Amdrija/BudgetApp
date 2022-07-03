using System.Data;
using FluentMigrator;

namespace BudgetApp.Migrations
{
    [Migration(202207031027)]
    public class Expensemigration : Migration
    {
        public override void Up()
        {
            this.Create.Table("Expense")
                .WithColumn("Id")
                .AsGuid()
                .PrimaryKey()
                .WithColumn("Name")
                .AsString()
                .NotNullable()
                .WithColumn("Amount")
                .AsDecimal()
                .NotNullable()
                .WithColumn("Date")
                .AsDateTime()
                .NotNullable()
                .WithColumn("Description")
                .AsString()
                .WithColumn("CategoryId")
                .AsGuid()
                .ForeignKey("Category", "Id")
                .OnDelete(Rule.None)
                .NotNullable();
        }

        public override void Down()
        {
            this.Delete.Table("Expense");
        }
    }
}