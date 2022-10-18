using Microsoft.AspNetCore.Mvc;
using MyFinancialTracker.api.Tags;
using MyFinancialTracker.api.Transactions.Bank;

namespace MyFinancialTracker.api.Transactions;

[ApiController, ApiVersion("1.0"), Route("api/V{version:apiVersion}/[controller]")]
public class TagController : ControllerBase
{

    private readonly TagService _service;

    public TagController(TagService service)
    {
        _service = service;
    }

    [HttpGet, Route("GetAll")]
    public IActionResult GetBankTransactions()
    {
        return Ok(_service.GetAll());
    }

    [HttpPost, Route("New")]
    public IActionResult NewTag(Tag tag)
    {
        _service.InsertOne(tag);
        return Ok("Successfully inserted tag");
    }
}