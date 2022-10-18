using MyFinancialTracker.api.Transactions.Bank;

namespace MyFinancialTracker.api.Tags;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Icon { get; set; } = null!;
    public string Color { get; set; } = null!;
    public List<BankTransaction> Transactions { get; set; } = null!;
}