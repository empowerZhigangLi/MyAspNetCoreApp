using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAspNetCoreApp.Models
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // 自增主键
        public long ContactId { get; set; }  // 作为主键

        [MaxLength(100)]
        public string DeviceContactId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string PhoneNumber { get; set; }

        public DateTime? ContactLastUpdated { get; set; }
    }
}