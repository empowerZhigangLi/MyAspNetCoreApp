using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// 注册控制器服务
builder.Services.AddControllers();

// 注册 MediatR，并扫描当前程序集中的所有 Handler
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// 注册 Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 配置 Swagger，仅在开发环境中启用
app.UseSwagger(); 
app.UseSwaggerUI();

// 中间件配置
app.UseHttpsRedirection();  // 强制 HTTPS 重定向
app.UseAuthorization();     // 启用授权中间件

// 映射控制器路由
app.MapControllers();

app.Run();