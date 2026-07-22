namespace E_Word_Api.Dtos;

/// <summary>
/// 每日签到结果
/// </summary>
public class CoinCheckinResultDto
{
    /// <summary>今日是否已签到（true=已签到不可再签）</summary>
    public bool AlreadyCheckedIn { get; set; }

    /// <summary>本次签到获得的 e币</summary>
    public int Earned { get; set; }

    /// <summary>签到后的当前余额</summary>
    public int Balance { get; set; }

    public DateTime CheckinTime { get; set; }
}
