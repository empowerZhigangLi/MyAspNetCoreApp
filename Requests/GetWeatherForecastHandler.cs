using MediatR;

// 处理器类，处理 GetWeatherForecastRequest
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
                new WeatherForecast(
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    Summaries[Random.Shared.Next(Summaries.Length)]
                ))
            .ToArray();

        return Task.FromResult(forecast);
    }
}