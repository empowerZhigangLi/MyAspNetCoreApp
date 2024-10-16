using MediatR;
using MyAspNetCoreApp.Data;
using MyAspNetCoreApp.Models;
using MyAspNetCoreApp.Requests;

namespace MyAspNetCoreApp.Handlers
{
    public class InsertContactHandler : IRequestHandler<InsertContactRequest, Contact>
    {
        private readonly MyDbContext _dbContext;

        public InsertContactHandler(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Contact> Handle(InsertContactRequest request, CancellationToken cancellationToken)
        {
            var contact = new Contact
            {
                DeviceContactId = request.DeviceContactId,
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                ContactLastUpdated = request.ContactLastUpdated
            };

            _dbContext.Contacts.Add(contact);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return contact;
        }
    }
}