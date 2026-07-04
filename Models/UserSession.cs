namespace E_Word_Api.Models;

/**
 * 用户当前的单词
 */
public class UserSession
{
    public long Id { get; set; }
    public string UserId { get; set; }
    public long BookId { get; set; }
}