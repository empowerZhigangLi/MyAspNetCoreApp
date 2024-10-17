using Microsoft.EntityFrameworkCore;
using MyAspNetCoreApp.Models;
using MyAspNetCoreApp.Repositories;

namespace MyAspNetCoreApp.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        // 定义你的 DbSet（表示数据库表）
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<AndroidSms> AndroidSms { get; set; }  
    }
    // 通用仓储实现类，自动使用 EF Core 进行数据库操作
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly MyDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(MyDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _dbSet.AsQueryable();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}