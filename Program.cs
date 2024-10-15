using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// 注册 MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// 注册 Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 配置 Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 使用 MediatR 重构后的 API 路由
app.MapGet("/weatherforecast/{days:int}", async (int days, IMediator mediator) =>
    {
        var result = await mediator.Send(new GetWeatherForecastRequest { Days = days });
        return Results.Ok(result);
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();