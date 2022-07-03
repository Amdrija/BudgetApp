using BudgetApp.Domain.Category;
using BudgetApp.Domain.Expense;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.EntityFramework
{
    public class BudgetAppContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public BudgetAppContext(DbContextOptions<BudgetAppContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                        .ToTable("Category");

            modelBuilder.Entity<Expense>()
                        .ToTable("Expense");
        }
    }
}