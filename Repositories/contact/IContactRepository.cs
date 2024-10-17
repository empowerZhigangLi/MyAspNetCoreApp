using MyAspNetCoreApp.Models;

namespace MyAspNetCoreApp.Repositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        // 如果有特殊的 Contact 操作，可以在这里添加额外方法
    }
}
