using MediatR;
using MyAspNetCoreApp.Responses;

namespace MyAspNetCoreApp.Requests
{
    public class SearchContactsRequest : IRequest<SearchContactsResponse>
    {
        public string? DeviceContactId { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
    }
}