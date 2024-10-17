using System;
using System.Collections.Generic;

namespace MyAspNetCoreApp.Responses
{
    public class SearchAndroidSmsResponse
    {
        public List<AndroidSmsLite> SmsMessages { get; set; }
        public int TotalCount { get; set; }

        public SearchAndroidSmsResponse()
        {
            SmsMessages = new List<AndroidSmsLite>();
        }
    }

    // 定义 AndroidSms 的简化信息，用于响应输出
    public class AndroidSmsLite
    {
        public long AndroidSmsId { get; set; }
        public string Address { get; set; }
        public string Body { get; set; }
        public string Status { get; set; }
        public DateTime? Date { get; set; }
    }
}