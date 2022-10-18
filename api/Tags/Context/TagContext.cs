using Microsoft.EntityFrameworkCore;

namespace MyFinancialTracker.api.Tags;
public class TagContext : DbContext
{
    public DbSet<Tag>? Tags { get; set; }

    public TagContext(DbContextOptions<TagContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tag>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }
}