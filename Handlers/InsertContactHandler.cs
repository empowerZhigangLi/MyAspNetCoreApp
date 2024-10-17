using MediatR;
using MyAspNetCoreApp.Models;
using MyAspNetCoreApp.Requests;
using MyAspNetCoreApp.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyAspNetCoreApp.Handlers
{
    public class InsertContactHandler : IRequestHandler<InsertContactRequest, List<Contact>>
    {
        private readonly MyDbContext _dbContext;

        public InsertContactHandler(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Contact>> Handle(InsertContactRequest request, CancellationToken cancellationToken)
        {
            // 将请求中的 ContactItem 转换为 Contact 实体
            var contacts = request.Contacts.Select(contactItem => new Contact
            {
                DeviceContactId = contactItem.DeviceContactId,
                Name = contactItem.Name,
                PhoneNumber = contactItem.PhoneNumber,
                ContactLastUpdated = contactItem.ContactLastUpdated
            }).ToList();

            // 批量插入联系人数据
            _dbContext.Contacts.AddRange(contacts);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return contacts;
        }
    }
}