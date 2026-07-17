
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
}
