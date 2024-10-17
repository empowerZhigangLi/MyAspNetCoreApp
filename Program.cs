using Microsoft.EntityFrameworkCore;
using MediatR;
using MyAspNetCoreApp.Data; // 引入数据库上下文所在的命名空间
using System.Reflection;
using MyAspNetCoreApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 从 appsettings.json 中获取连接字符串
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 注册数据库上下文
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(connectionString));

// 注册控制器服务
builder.Services.AddControllers();

// 注册 IRepository
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// 注册 MediatR，并扫描当前程序集中的所有 Handler
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

// 添加健康检查服务
builder.Services.AddHealthChecks();
// 注册 Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers(options =>
{
    // 配置模型绑定行为，避免空字符串触发验证错误
}).ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});


var app = builder.Build();

// 配置 Swagger，仅在开发环境中启用
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 中间件配置
app.UseHttpsRedirection();  // 强制 HTTPS 重定向
app.UseAuthorization();     // 启用授权中间件

// 映射健康检查路由
app.MapHealthChecks("/health"); // 通过访问 /health 检查健康状态
// 映射控制器路由
app.MapControllers();

app.Run();