namespace E_Word_Api.Models;

public class UserSession
{
    public long Id { get; set; }
    public string UserId { get; set; }
    public long BookId { get; set; }
    /// <summary>连续正确次数</summary>
    public int CorrectStreak { get; set; }
    /// <summary>总答题次数</summary>
    public int TotalAttempts { get; set; }
}
