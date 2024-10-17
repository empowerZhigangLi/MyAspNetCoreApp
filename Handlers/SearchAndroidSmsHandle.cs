using MediatR;
using MyAspNetCoreApp.Repositories;
using MyAspNetCoreApp.Requests;
using MyAspNetCoreApp.Responses;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyAspNetCoreApp.Models;

namespace MyAspNetCoreApp.Handlers
{
    public class SearchAndroidSmsHandler : IRequestHandler<SearchAndroidSmsRequest, SearchAndroidSmsResponse>
    {
        private readonly IRepository<AndroidSms> _repository;

        public SearchAndroidSmsHandler(IRepository<AndroidSms> repository)
        {
            _repository = repository;
        }

        public async Task<SearchAndroidSmsResponse> Handle(SearchAndroidSmsRequest request, CancellationToken cancellationToken)
        {
            // 获取 IQueryable 对象
            var smsQuery = _repository.GetQueryable();  

            // 根据 Address 进行过滤
            if (!string.IsNullOrEmpty(request.Address))
            {
                smsQuery = smsQuery.Where(sms => sms.Address.Contains(request.Address));
            }

            // 根据 Body 进行过滤
            if (!string.IsNullOrEmpty(request.Body))
            {
                smsQuery = smsQuery.Where(sms => sms.Body.Contains(request.Body));
            }

            // 根据 Status 进行过滤
            if (!string.IsNullOrEmpty(request.Status))
            {
                smsQuery = smsQuery.Where(sms => sms.Status == request.Status);
            }

            // 根据日期范围进行过滤
            if (request.FromDate.HasValue)
            {
                smsQuery = smsQuery.Where(sms => sms.Date >= request.FromDate.Value);
            }

            if (request.ToDate.HasValue)
            {
                smsQuery = smsQuery.Where(sms => sms.Date <= request.ToDate.Value);
            }

            // 执行查询并转换为 AndroidSmsLite
            var smsMessages = await smsQuery.Select(sms => new AndroidSmsLite
            {
                AndroidSmsId = sms.AndroidSmsId,
                Address = sms.Address,
                Body = sms.Body,
                Status = sms.Status,
                Date = sms.Date
            }).ToListAsync();

            var response = new SearchAndroidSmsResponse
            {
                SmsMessages = smsMessages,
                TotalCount = smsMessages.Count
            };

            return response;
        }
    }
}
