using E_Word_Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Word_Api.Datas;

public class EWordDbContext(DbContextOptions<EWordDbContext> options) : IdentityDbContext<AppUser, IdentityRole, string>(options)
{
    public DbSet<Word> Words { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        var roleAdminId = Guid.NewGuid().ToString();
        var roleUserId = Guid.NewGuid().ToString();
        var adminId = Guid.NewGuid().ToString();
        // 生成角色
        var roles = new List<IdentityRole>
        {
            new()
            {
                Id = roleAdminId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new()
            {
                Id = roleUserId,
                Name = "User",
                NormalizedName = "USER"
            }
        };
        builder.Entity<IdentityRole>().HasData(roles);
        // 生成管理员
        var admin = new AppUser
        {
            Id = adminId,
            UserName = "admin@eword.com",
            NormalizedUserName = "ADMIN@EWORD.COM",
            Email = "admin@eword.com",
            NickName = "Admin",
            City = "北京市",
            NormalizedEmail = "ADMIN@EWORD.COM",
            EmailConfirmed = false,
            PhoneNumber = "17323895436",
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnabled = true,
            AccessFailedCount = 0,
            SecurityStamp = Guid.NewGuid().ToString("D"),
            ConcurrencyStamp = Guid.NewGuid().ToString("D"),
            CreatedAt = DateTime.UtcNow
        };
        var passwordHasher = new PasswordHasher<AppUser>();
        admin.PasswordHash = passwordHasher.HashPassword(admin, "Admin123.");
        builder.Entity<AppUser>().HasData(admin);
        // 生成管理员的角色
        var userRole = new IdentityUserRole<string>
        {
            RoleId = roleAdminId,
            UserId = adminId
        };
        builder.Entity<IdentityUserRole<string>>().HasData(userRole);
    }
}