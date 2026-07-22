namespace E_Word_Api.Dtos;

/// <summary>
/// e币 余额查询响应
/// </summary>
public class CoinBalanceDto
{
    public int Balance { get; set; }
    public int TotalEarned { get; set; }
    public bool CheckedInToday { get; set; }
}
