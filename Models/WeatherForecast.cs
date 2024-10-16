using System.ComponentModel.DataAnnotations;

namespace MyAspNetCoreApp.Models
{
    public record WeatherForecast
    {
        [Key] // 指定 Id 为主键
        public int Id { get; init; }

        public DateOnly Date { get; init; }
        public int TemperatureC { get; init; }
        public string? Summary { get; init; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}