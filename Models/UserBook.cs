
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Word_Api.Models;

/** 
 * 用户所选词书
 */
public class UserBook
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string UserId { get; set; }
    public string BookName { get; set; }
}