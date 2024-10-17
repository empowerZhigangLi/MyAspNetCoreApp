using MediatR;
using MyAspNetCoreApp.Responses;

namespace MyAspNetCoreApp.Requests
{
    public class SearchAndroidSmsRequest : IRequest<SearchAndroidSmsResponse>
    {
        public string? Address { get; set; }
        public string? Body { get; set; }
        public string? Status { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
  
}