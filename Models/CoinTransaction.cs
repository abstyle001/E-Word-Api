using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Word_Api.Models;

/// <summary>
/// e币 交易流水记录
/// </summary>
public class CoinTransaction
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    /// <summary>用户ID</summary>
    public string UserId { get; set; } = string.Empty;

    /// <summary>变动金额（正=赚取，负=消费）</summary>
    public int Amount { get; set; }

    /// <summary>交易类型：MasterWord / ReviewPass / DailyCheckin</summary>
    [MaxLength(50)]
    public string Type { get; set; } = string.Empty;

    /// <summary>描述文字</summary>
    [MaxLength(200)]
    public string Description { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
