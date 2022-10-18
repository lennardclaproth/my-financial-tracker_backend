using Microsoft.EntityFrameworkCore;

namespace MyFinancialTracker.api.Transactions.Bank;
public class BankTransactionContext : DbContext
{
    public DbSet<BankTransaction>? BankTransactions { get; set; }

    public BankTransactionContext(DbContextOptions<BankTransactionContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BankTransaction>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }
}