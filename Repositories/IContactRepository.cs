using MyAspNetCoreApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAspNetCoreApp.Repositories
{
    public interface IContactRepository : IRepository<Contact>
    {
        // 定义特定的查询方法，允许使用可选参数进行过滤
        Task<List<Contact>> SearchContactsAsync(string? deviceContactId, string? name, string? phoneNumber);
    }
}