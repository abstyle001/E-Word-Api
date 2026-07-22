
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Word_Api.Models;

public class UserWord
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string UserId { get; set; }

    public long WordId { get; set; }
    public string OriginBook { get; set; }
    public string Status { get; set; }
    /// <summary>掌握前总答题次数</summary>
    public int Attempts { get; set; }
    /// <summary>掌握时间</summary>
    public DateTime MasteredAt { get; set; }
    /// <summary>已成功复习次数 (0=初次掌握, 1=第一次复习通过, ...)</summary>
    public int RepetitionCount { get; set; }
    /// <summary>当前间隔天数</summary>
    public int IntervalDays { get; set; } = 1;
    /// <summary>下次复习时间 (NULL=待首次复习)</summary>
    public DateTime? NextReviewAt { get; set; }
    /// <summary>上次复习时间</summary>
    public DateTime? LastReviewedAt { get; set; }
}
