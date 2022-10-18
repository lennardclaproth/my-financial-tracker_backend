using MyFinancialTracker.api.Utils;
using MyFinancialTracker.api.Filter;

namespace MyFinancialTracker.api.Transactions.Bank;

public class BankTransactionService
{
    private readonly BankTransactionRepository _repository;

    public BankTransactionService(BankTransactionRepository repository)
    {
        _repository = repository;
    }

    public void Import(List<BankTransaction> transactions)
    {
        var existingTransactions = _repository.AllTransactions();
        var transactionsToInsert = new List<BankTransaction>();

        foreach (var item in transactions)
        {
            string hashString = item.DateTimeUnix.ToString() + item.ImportType + item.Balance.ToString() + item.SenderReceiver + item.AmountInEur.ToString();
            item.Checksum = HashBuilder.Build(hashString);
            if (!EnumerableUtils.Contains<BankTransaction>(existingTransactions, item, "Checksum")) transactionsToInsert.Add(item);
        }
        _repository.InsertMany(transactionsToInsert);
        _repository.SaveChanges();
    }

    public List<BankTransaction> BankTransactions()
    {
        return _repository.AllTransactions().ToList();
    }

    public List<CashFlowOverview> CashFlowOverview(string dateFilter)
    {
        DateFilter datefilter = DateFilterBuilder.build(dateFilter);
        List<CashFlowOverview> overview = _repository.CashFlowOverview(datefilter.dateStart, datefilter.dateEnd).ToList();
        if (overview.Count > 0)
        {
            overview[0].NetProfitLoss = overview[0].Incoming - overview[0].Outgoing;
            for (int i = 1; i < overview.Count(); i++)
            {
                var newOverview = overview[i];
                var oldOverview = overview[i - 1];

                newOverview.IncomingDelta = EnumerableUtils.CalcDifference<CashFlowOverview>(oldOverview, newOverview, "Incoming");
                newOverview.OutgoingDelta = EnumerableUtils.CalcDifference<CashFlowOverview>(oldOverview, newOverview, "Outgoing");
                newOverview.NetProfitLoss = newOverview.Incoming - newOverview.Outgoing;
                newOverview.NetProfitLossDelta = EnumerableUtils.CalcDifference<CashFlowOverview>(oldOverview, newOverview, "NetProfitLoss");
            }
        }

        return overview;
    }
}