using MediatR;
using MyAspNetCoreApp.Models;

public class GetWeatherForecastHandler : IRequestHandler<GetWeatherForecastRequest, WeatherForecast[]>
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", 
        "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public Task<WeatherForecast[]> Handle(GetWeatherForecastRequest request, CancellationToken cancellationToken)
    {
        var forecast = Enumerable.Range(1, request.Days).Select(index =>
            new WeatherForecast
            {
                Id = index,  // 初始化主键 Id
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();

        return Task.FromResult(forecast);
    }
}