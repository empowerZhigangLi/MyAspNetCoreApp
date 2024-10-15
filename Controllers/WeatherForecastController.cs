using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IMediator _mediator;

    public WeatherForecastController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet("{days:int}")]
    public async Task<IActionResult> Get(int days)
    {
        var result = await _mediator.Send(new GetWeatherForecastRequest { Days = days });
        return Ok(result);
    }
}