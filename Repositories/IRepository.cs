
namespace MyAspNetCoreApp.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();  // 返回所有实体的异步方法
        IQueryable<TEntity> GetQueryable();        // 返回 IQueryable<TEntity>
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}