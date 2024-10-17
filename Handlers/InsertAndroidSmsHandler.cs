using MediatR;
using MyAspNetCoreApp.Data;
using MyAspNetCoreApp.Models;
using MyAspNetCoreApp.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyAspNetCoreApp.Handlers
{
    public class InsertAndroidSmsHandler : IRequestHandler<InsertAndroidSmsRequest, List<AndroidSms>>
    {
        private readonly MyDbContext _dbContext;

        public InsertAndroidSmsHandler(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AndroidSms>> Handle(InsertAndroidSmsRequest request, CancellationToken cancellationToken)
        {
            // 将请求中的 AndroidSmsItem 转换为 AndroidSms 实体
            var androidSmsList = request.SmsMessages.Select(smsItem => new AndroidSms
            {
                LegacyUserId = smsItem.LegacyUserId,
                CreatedAt = smsItem.CreatedAt,
                SmsId = smsItem.SmsId,
                Address = smsItem.Address,
                Body = smsItem.Body,
                Date = smsItem.Date,
                Type = smsItem.Type,
                Read = smsItem.Read,
                ThreadId = smsItem.ThreadId,
                Protocol = smsItem.Protocol,
                Status = smsItem.Status
            }).ToList();

            // 批量插入
            _dbContext.AndroidSms.AddRange(androidSmsList);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return androidSmsList;
        }
    }
}