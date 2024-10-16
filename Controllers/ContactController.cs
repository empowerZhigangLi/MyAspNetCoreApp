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
}