using Microsoft.EntityFrameworkCore;
using Orien.FinanceBuddy.Data.Entity;

namespace Orien.FinanceBuddy.Data
{
    public class FinanceBuddyDbContext : DbContext
    {
        public FinanceBuddyDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinanceBuddyDbContext).Assembly);
        }
    }
}
