using Microsoft.EntityFrameworkCore;
using MyAspNetCoreApp.Models;

namespace MyAspNetCoreApp.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        // 定义你的 DbSet（表示数据库表）
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}