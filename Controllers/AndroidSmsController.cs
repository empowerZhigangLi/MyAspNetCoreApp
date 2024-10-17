using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Requests;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class AndroidSmsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AndroidSmsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AddAndroidSms([FromBody] InsertAndroidSmsRequest request)
    {
        var androidSms = await _mediator.Send(request);
        return Ok(androidSms);
    }
    
    [HttpPost("search")]
    public async Task<IActionResult> SearchSms([FromBody] SearchAndroidSmsRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}