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

    // 批量插入 AndroidSms 数据
    [HttpPost("insert")]
    public async Task<IActionResult> InsertAndroidSms([FromBody] InsertAndroidSmsRequest request)
    {
        var smsList = await _mediator.Send(request);
        return Ok(smsList);
    }
    
    [HttpPost("search")]
    public async Task<IActionResult> SearchSms([FromBody] SearchAndroidSmsRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}