using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Word_Api.Models;

/// <summary>
/// 用户 e币 钱包
/// </summary>
public class UserWallet
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    /// <summary>用户ID，与 AspNetUsers 关联</summary>
    public string UserId { get; set; } = string.Empty;

    /// <summary>当前余额</summary>
    public int Balance { get; set; }

    /// <summary>累计赚取（统计用）</summary>
    public int TotalEarned { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
