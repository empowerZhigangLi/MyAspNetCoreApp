using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Requests;

[ApiController]
[Route("[controller]")]
public class ContactController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContactController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // 批量插入联系人
    [HttpPost("insert")]
    public async Task<IActionResult> InsertContacts([FromBody] InsertContactRequest request)
    {
        var contacts = await _mediator.Send(request);
        return Ok(contacts);
    }
    
    // HTTP POST 请求，传入可选的查询参数
    [HttpPost("search")]
    public async Task<IActionResult> SearchContacts([FromBody] SearchContactsRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}