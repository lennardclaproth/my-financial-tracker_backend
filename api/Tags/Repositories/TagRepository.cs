
namespace MyFinancialTracker.api.Tags;
public class TagRepository
{
    private readonly TagContext _context;
    public TagRepository(TagContext context)
    {
        _context = context;
    }

    public void InsertOne(Tag tag)
    {
        _context.Add(tag);
        // int addedCount = _context.ChangeTracker.Entries<BankTransaction>()
        // .Count(e => e.State == EntityState.Added);
    }

    public IEnumerable<Tag> AllTags()
    {
        return _context.Tags.ToList();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}