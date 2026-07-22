using System.Security.Claims;
using E_Word_Api.Dtos;
using E_Word_Api.Repositories;
using E_Word_Api.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Word_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CoinController(CoinRepository coinRepository) : ControllerBase
{
    /// <summary>查询当前用户 e币 余额</summary>
    [HttpGet("balance")]
    [Authorize(Roles = RoleType.User)]
    public async Task<CoinBalanceDto> GetBalance()
    {
        var userId = User.FindFirstValue("id");
        return await coinRepository.GetBalanceInfoAsync(userId ?? string.Empty);
    }

    /// <summary>每日签到，+10 e币</summary>
    [HttpPost("checkin")]
    [Authorize(Roles = RoleType.User)]
    public async Task<CoinCheckinResultDto> Checkin()
    {
        var userId = User.FindFirstValue("id");
        return await coinRepository.DoCheckinAsync(userId ?? string.Empty);
    }

    /// <summary>查询交易流水（分页）</summary>
    [HttpGet("transactions")]
    [Authorize(Roles = RoleType.User)]
    public async Task<List<CoinTransactionDto>> GetTransactions([FromQuery] int page = 1, [FromQuery] int size = 20)
    {
        var userId = User.FindFirstValue("id");
        return await coinRepository.GetTransactionsAsync(userId ?? string.Empty, page, size);
    }
}
