namespace MyFinancialTracker.api.Transactions.Bank;

public class CashFlowOverview
{
    public string DateString { get; set; } = null!;
    public double Incoming { get; set; }
    public double IncomingDelta { get; set; }
    public double Outgoing { get; set; }
    public double OutgoingDelta { get; set; }
    public double NetProfitLoss { get; set; }
    public double NetProfitLossDelta { get; set; }
}
