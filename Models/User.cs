using System;
using System.ComponentModel.DataAnnotations;

namespace MyAspNetCoreApp.Models
{
    public class User
    {
        [Key] // 主键
        public int Id { get; set; }

        [Required]
        [MaxLength(50)] // 用户名最多50个字符
        public string Username { get; set; }

        [Required]
        [MaxLength(100)] // 邮箱最多100个字符
        public string Email { get; set; }

        [Required]
        [MaxLength(256)] // 哈希后的密码最多256个字符
        public string PasswordHash { get; set; }

        [Required] // 必填字段，不能为 null
        [MaxLength(50)] // 电话号码最多50个字符
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? LastLogin { get; set; }

        [MaxLength(100)] // 用户的全名
        public string? FullName { get; set; }

        // 标志是否为管理员
        public bool IsAdmin { get; set; } = false;

        // 标志用户是否被锁定
        public bool IsLocked { get; set; } = false;
        
        // 新增字段：标志是否是旧系统用户
        public bool IsOldAppUser { get; set; } = false;  // 默认值为 false
    }
}