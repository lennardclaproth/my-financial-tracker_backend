using Microsoft.EntityFrameworkCore;

namespace MyFinancialTracker.api.Transactions.Bank;
public class BankTransactionRepository
{
    private readonly BankTransactionContext _context;
    public BankTransactionRepository(BankTransactionContext context)
    {
        _context = context;
    }

    public void InsertMany(List<BankTransaction> transactions)
    {
        _context.AddRange(transactions);
        int addedCount = _context.ChangeTracker.Entries<BankTransaction>()
        .Count(e => e.State == EntityState.Added);
    }

    public IEnumerable<BankTransaction> AllTransactions()
    {
        return _context.BankTransactions.ToList();
    }

    public IEnumerable<CashFlowOverview> CashFlowOverview(DateTime? dateStart, DateTime dateEnd)
    {
        var result = new List<CashFlowOverview>();
        
        var query = from t in _context.BankTransactions
                    where t.DateTime > dateStart && t.DateTime < dateEnd
                    group t by new { month = t.DateTime.Month, year = t.DateTime.Year } into tg
                    orderby tg.Key.year, tg.Key.month
                    select new CashFlowOverview { 
                        DateString = string.Format("{0}-{1}",tg.Key.year, tg.Key.month),
                        Incoming = tg.Sum(t => t.AmountInEur > 0 ? t.AmountInEur : 0),
                        Outgoing = Math.Abs(tg.Sum(t => t.AmountInEur < 0 ? t.AmountInEur : 0))
                        };
                            
        foreach (var item in query)
        {
            result.Add(item);
        }
        return result;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}