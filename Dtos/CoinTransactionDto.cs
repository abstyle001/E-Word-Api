namespace E_Word_Api.Dtos;

/// <summary>
/// e币 交易流水记录
/// </summary>
public class CoinTransactionDto
{
    public int Amount { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
