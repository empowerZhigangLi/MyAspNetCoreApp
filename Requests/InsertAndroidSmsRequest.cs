using MediatR;
using MyAspNetCoreApp.Models;
using System.Collections.Generic;

namespace MyAspNetCoreApp.Requests
{
    public class InsertAndroidSmsRequest : IRequest<List<AndroidSms>>
    {
        public List<AndroidSmsItem> SmsMessages { get; set; }

        public class AndroidSmsItem
        {
            public int LegacyUserId { get; set; }
            public DateTime CreatedAt { get; set; }
            public string SmsId { get; set; }
            public string Address { get; set; }
            public string Body { get; set; }
            public DateTime? Date { get; set; }
            public string Type { get; set; }
            public string Read { get; set; }
            public string ThreadId { get; set; }
            public string Protocol { get; set; }
            public string Status { get; set; }
        }
    }
}