using MyFinancialTracker.api.Utils;
using MyFinancialTracker.api.Filter;
using MyFinancialTracker.api.Tags;

namespace MyFinancialTracker.api.Transactions.Bank;

public class TagService
{
    private readonly TagRepository _repository;

    public TagService(TagRepository repository)
    {
        _repository = repository;
    }

    public List<Tag> GetAll()
    {
        return _repository.AllTags().ToList();
    }

    public void InsertOne(Tag tag){
        _repository.InsertOne(tag);
        _repository.SaveChanges();
    }
}