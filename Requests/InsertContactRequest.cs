using MediatR;
using MyAspNetCoreApp.Models;


namespace MyAspNetCoreApp.Requests
{
    public class InsertContactRequest : IRequest<List<Contact>>
    {
        public List<ContactItem> Contacts { get; set; }

        public class ContactItem
        {
            public string DeviceContactId { get; set; }
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public DateTime? ContactLastUpdated { get; set; }
        }
    }
}
