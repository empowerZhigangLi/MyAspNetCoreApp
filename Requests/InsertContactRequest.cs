using MediatR;
using MyAspNetCoreApp.Models;

namespace MyAspNetCoreApp.Requests
{
    public class InsertContactRequest : IRequest<Contact>
    {
        public string DeviceContactId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? ContactLastUpdated { get; set; }
    }
}