using Microsoft.AspNetCore.Identity;

namespace E_Word_Api.Models;

public class AppUser : IdentityUser
{
    // 用户姓名or昵称
    [PersonalData] public string? NickName { get; set; } = string.Empty;
    // 用户所在城市
    [PersonalData] public string? City { get; set; } = string.Empty;
    // 创建时间
    [PersonalData] public DateTime CreatedAt { get; set; }
    // 用户头像地址
    [PersonalData] public string? Avatar { get; set; }
}