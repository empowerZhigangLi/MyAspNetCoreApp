using MediatR;
using MyAspNetCoreApp.Repositories;
using MyAspNetCoreApp.Requests;
using MyAspNetCoreApp.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace MyAspNetCoreApp.Handlers
{
    public class SearchContactsHandler : IRequestHandler<SearchContactsRequest, SearchContactsResponse>
    {
        private readonly IContactRepository _contactRepository;

        public SearchContactsHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<SearchContactsResponse> Handle(SearchContactsRequest request, CancellationToken cancellationToken)
        {
            var contacts = await _contactRepository.SearchContactsAsync(request.DeviceContactId, request.Name, request.PhoneNumber);
            
            return new SearchContactsResponse
            {
                Contacts = contacts,
                TotalCount = contacts.Count
            };
        }
    }
}