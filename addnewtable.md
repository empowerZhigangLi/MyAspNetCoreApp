### 步骤 1：定义 User 实体类
确保你的 User 实体类正确定义
User.cs
``` using System;
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

        [Required]
        [MaxLength(50)] // 可选字段，例如用户的电话号码
        public string? PhoneNumber { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? LastLogin { get; set; }

        [MaxLength(100)] // 用户的全名
        public string? FullName { get; set; }

        // 标志是否为管理员
        public bool IsAdmin { get; set; } = false;
    }
}
 ```

### 步骤 2：修改 MyDbContext 类并使用 Fluent API 设置唯一约束
在 MyDbContext 的 OnModelCreating 方法中使用 Fluent API 为 PhoneNumber 设置唯一索引。

MyDbContext.cs
```
using Microsoft.EntityFrameworkCore;
using MyAspNetCoreApp.Models;

namespace MyAspNetCoreApp.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        // 定义 DbSet
        public DbSet<User> Users { get; set; }
        public DbSet<WeatherForecast> WeatherForecast { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<AndroidSms> AndroidSms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 为 User 实体中的 PhoneNumber 设置唯一约束
            modelBuilder.Entity<User>()
                .HasIndex(u => u.PhoneNumber)
                .IsUnique()//确保该索引是唯一的。
        }
    }
}
```

### 步骤 3：创建迁移
接下来，使用 dotnet ef 工具来生成一个新的迁移，该迁移将为 PhoneNumber 字段添加唯一约束。

在终端中运行以下命令：
```
dotnet ef migrations add AddUniqueConstraintToPhoneNumber

```

### 步骤 4：应用迁移
运行以下命令将迁移应用到数据库中，从而更新表结构并添加 PhoneNumber 的唯一约束：
```
dotnet ef database update
```
生成的迁移文件示例
你可以在 Migrations 文件夹中找到迁移文件，以下是示例内容：
```
public partial class AddUniqueConstraintToPhoneNumber : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateIndex(
            name: "IX_Users_PhoneNumber",
            table: "Users",
            column: "PhoneNumber",
            unique: true,
            filter: "[PhoneNumber] IS NOT NULL");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_Users_PhoneNumber",
            table: "Users");
    }
}

```