using MediatR;

// 请求类，返回一个 WeatherForecast 数组
public class GetWeatherForecastRequest : IRequest<WeatherForecast[]>
{
    public int Days { get; set; } = 5; // 生成多少天的天气数据
}