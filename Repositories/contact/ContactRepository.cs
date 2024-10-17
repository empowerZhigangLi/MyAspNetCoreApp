using MyAspNetCoreApp.Data;
using MyAspNetCoreApp.Models;

namespace MyAspNetCoreApp.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(MyDbContext dbContext) : base(dbContext)
        {
        }

        // 如果有特殊的 Contact 操作，可以在这里实现额外方法
    }
}