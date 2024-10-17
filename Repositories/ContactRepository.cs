using Microsoft.EntityFrameworkCore;
using MyAspNetCoreApp.Models;
using MyAspNetCoreApp.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAspNetCoreApp.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        private readonly MyDbContext _context;

        public ContactRepository(MyDbContext context) : base(context)
        {
            _context = context;
        }

        // 实现带有可选参数的查询方法
        public async Task<List<Contact>> SearchContactsAsync(string? deviceContactId, string? name, string? phoneNumber)
        {
            var query = _context.Contacts.AsQueryable();

            if (!string.IsNullOrEmpty(deviceContactId))
            {
                query = query.Where(c => c.DeviceContactId == deviceContactId);
            }

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                query = query.Where(c => c.PhoneNumber.Contains(phoneNumber));
            }

            return await query.ToListAsync();
        }
    }
}