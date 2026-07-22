namespace E_Word_Api.Dtos;

/// <summary>
/// 复习单词结果
/// </summary>
public class WordReviewResultDto
{
    /// <summary>本次答题是否正确</summary>
    public bool Correct { get; set; }
    /// <summary>当前复习次数</summary>
    public int RepetitionCount { get; set; }
    /// <summary>下次复习时间</summary>
    public DateTime NextReviewAt { get; set; }
    /// <summary>当前间隔天数</summary>
    public int IntervalDays { get; set; }
    /// <summary>本次获得的 e币 奖励（0=无奖励）</summary>
    public int CoinReward { get; set; }
}
