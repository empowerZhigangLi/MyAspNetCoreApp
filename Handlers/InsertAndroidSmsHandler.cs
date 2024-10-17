using MediatR;
using MyAspNetCoreApp.Data;
using MyAspNetCoreApp.Models;
using MyAspNetCoreApp.Requests;
using System.Threading;
using System.Threading.Tasks;

namespace MyAspNetCoreApp.Handlers
{
    public class InsertAndroidSmsHandler : IRequestHandler<InsertAndroidSmsRequest, AndroidSms>
    {
        private readonly MyDbContext _dbContext;

        public InsertAndroidSmsHandler(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AndroidSms> Handle(InsertAndroidSmsRequest request, CancellationToken cancellationToken)
        {
            var androidSms = new AndroidSms
            {
                LegacyUserId = request.LegacyUserId,
                CreatedAt = request.CreatedAt,
                SmsId = request.SmsId,
                Address = request.Address,
                Body = request.Body,
                Date = request.Date,
                Type = request.Type,
                Read = request.Read,
                ThreadId = request.ThreadId,
                Protocol = request.Protocol,
                Status = request.Status
            };

            _dbContext.AndroidSms.Add(androidSms);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return androidSms;
        }
    }
}