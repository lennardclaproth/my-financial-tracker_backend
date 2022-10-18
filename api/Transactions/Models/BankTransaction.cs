namespace MyFinancialTracker.api.Transactions.Bank;

public class BankTransaction
{
    public int Id { get; set; }

    public long DateTimeUnix { get; set; }

    public string ImportType { get; set; } = null!;

    public DateTime DateTime { get; set; }

    public string SenderReceiver { get; set; } = null!;

    public double AmountInEur { get; set; }
    public double Balance { get; set; }
    public string? Checksum { get; set; }
    public int TagId { get; set; }
    public int UserId { get; set; }
}