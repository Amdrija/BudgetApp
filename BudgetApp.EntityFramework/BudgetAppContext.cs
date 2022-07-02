using BudgetApp.Domain.Category;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.EntityFramework
{
    public class BudgetAppContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public BudgetAppContext(DbContextOptions<BudgetAppContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                        .ToTable("Category");
        }
    }
}