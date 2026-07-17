namespace E_Word_Api.Dtos;

public class WordLearnResultDto
{
    /// <summary>本次是否已掌握（连续正确达到阈值）</summary>
    public bool Mastered { get; set; }
    /// <summary>当前连续正确次数</summary>
    public int CurrentStreak { get; set; }
}
