using System;
using System.ComponentModel.DataAnnotations;

namespace MyAspNetCoreApp.Models
{
    public class AndroidSms
    {
        [Key]
        public long AndroidSmsId { get; set; }

        public int LegacyUserId { get; set; }

        public DateTime CreatedAt { get; set; }

        [MaxLength(100)]
        public string SmsId { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(1000)]
        public string Body { get; set; }

        public DateTime? Date { get; set; }

        [MaxLength(20)]
        public string Type { get; set; }

        [MaxLength(20)]
        public string Read { get; set; }

        [MaxLength(100)]
        public string ThreadId { get; set; }

        [MaxLength(20)]
        public string Protocol { get; set; }

        [MaxLength(20)]
        public string Status { get; set; }
    }
}