namespace E_Word_Api.Dtos;

public class WordLearnResultDto
{
    /// <summary>本次是否已掌握（连续正确达到阈值）</summary>
    public bool Mastered { get; set; }
    /// <summary>当前连续正确次数</summary>
    public int CurrentStreak { get; set; }
    /// <summary>本次获得的 e币 奖励（0=无奖励）</summary>
    public int CoinReward { get; set; }
}
