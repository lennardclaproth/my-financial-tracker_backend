using Microsoft.AspNetCore.Mvc;
using MyFinancialTracker.api.Transactions.Bank;

namespace MyFinancialTracker.api.Transactions;

[ApiController, ApiVersion("1.0"), Route("api/V{version:apiVersion}/[controller]")]
public class TransactionController : ControllerBase
{

    private readonly BankTransactionService _service;

    public TransactionController(BankTransactionService service)
    {
        _service = service;
    }

    [HttpGet, Route("Bank")]
    public IActionResult GetBankTransactions()
    {
        return Ok(_service.BankTransactions());
    }

    [HttpGet, Route("Bank/CashFlow")]
    public IActionResult GetBankTransactionsOverview(string? filter)
    {
        var _filter = string.IsNullOrEmpty(filter) ? "YTD" : filter;
        return Ok(_service.CashFlowOverview(_filter));
    }

    [HttpPost, Route("Bank/Import")]
    public IActionResult Post(List<BankTransaction> transactions)
    {
        _service.Import(transactions);
        return Ok("success");
    }
}