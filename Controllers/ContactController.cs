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

    [HttpPost]
    public async Task<IActionResult> AddContact([FromBody] InsertContactRequest request)
    {
        var contact = await _mediator.Send(request);
        return Ok(contact);
    }
    
    // HTTP POST 请求，传入可选的查询参数
    [HttpPost("search")]
    public async Task<IActionResult> SearchContacts([FromBody] SearchContactsRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}