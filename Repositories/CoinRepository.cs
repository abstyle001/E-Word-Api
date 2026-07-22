using E_Word_Api.Datas;
using E_Word_Api.Dtos;
using E_Word_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Word_Api.Repositories;

/// <summary>
/// e币 钱包和交易数据操作
/// </summary>
public class CoinRepository(EWordDbContext db)
{
    public const int MasterWordReward = 5;
    public const int ReviewPassReward = 2;
    public const int DailyCheckinReward = 10;

    /// <summary>获取或创建用户钱包（懒初始化）</summary>
    public async Task<UserWallet> GetOrCreateWalletAsync(string userId)
    {
        var wallet = await db.UserWallets
            .FirstOrDefaultAsync(w => w.UserId == userId);

        if (wallet == null)
        {
            wallet = new UserWallet
            {
                UserId = userId,
                Balance = 0,
                TotalEarned = 0,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            db.UserWallets.Add(wallet);
            await db.SaveChangesAsync();
        }

        return wallet;
    }

    /// <summary>查询余额</summary>
    public async Task<int> GetBalanceAsync(string userId)
    {
        var wallet = await GetOrCreateWalletAsync(userId);
        return wallet.Balance;
    }

    /// <summary>查询完整余额信息（含是否已签到）</summary>
    public async Task<CoinBalanceDto> GetBalanceInfoAsync(string userId)
    {
        var wallet = await GetOrCreateWalletAsync(userId);
        var checkedIn = await HasCheckedInTodayAsync(userId);
        return new CoinBalanceDto
        {
            Balance = wallet.Balance,
            TotalEarned = wallet.TotalEarned,
            CheckedInToday = checkedIn
        };
    }

    /// <summary>加币（原子操作：更新余额 + 插入流水，单次 SaveChangesAsync）</summary>
    public async Task<int> AddCoinsAsync(string userId, int amount, string type, string description)
    {
        var wallet = await GetOrCreateWalletAsync(userId);
        wallet.Balance += amount;
        wallet.TotalEarned += amount;
        wallet.UpdatedAt = DateTime.UtcNow;

        var transaction = new CoinTransaction
        {
            UserId = userId,
            Amount = amount,
            Type = type,
            Description = description,
            CreatedAt = DateTime.UtcNow
        };
        db.CoinTransactions.Add(transaction);

        await db.SaveChangesAsync();
        return wallet.Balance;
    }

    /// <summary>查今日是否已签到（按 UTC 日期判断）</summary>
    public async Task<bool> HasCheckedInTodayAsync(string userId)
    {
        var todayStart = DateTime.UtcNow.Date;
        var todayEnd = todayStart.AddDays(1);

        return await db.CoinTransactions
            .AnyAsync(t => t.UserId == userId
                && t.Type == "DailyCheckin"
                && t.CreatedAt >= todayStart
                && t.CreatedAt < todayEnd);
    }

    /// <summary>执行每日签到</summary>
    public async Task<CoinCheckinResultDto> DoCheckinAsync(string userId)
    {
        var alreadyCheckedIn = await HasCheckedInTodayAsync(userId);
        if (alreadyCheckedIn)
        {
            var wallet = await GetOrCreateWalletAsync(userId);
            return new CoinCheckinResultDto
            {
                AlreadyCheckedIn = true,
                Earned = 0,
                Balance = wallet.Balance,
                CheckinTime = DateTime.UtcNow
            };
        }

        var newBalance = await AddCoinsAsync(userId, DailyCheckinReward, "DailyCheckin", "每日签到");

        return new CoinCheckinResultDto
        {
            AlreadyCheckedIn = false,
            Earned = DailyCheckinReward,
            Balance = newBalance,
            CheckinTime = DateTime.UtcNow
        };
    }

    /// <summary>查询交易流水（分页，按时间倒序）</summary>
    public async Task<List<CoinTransactionDto>> GetTransactionsAsync(string userId, int page, int size)
    {
        return await db.CoinTransactions
            .Where(t => t.UserId == userId)
            .OrderByDescending(t => t.CreatedAt)
            .Skip((page - 1) * size)
            .Take(size)
            .Select(t => new CoinTransactionDto
            {
                Amount = t.Amount,
                Type = t.Type,
                Description = t.Description,
                CreatedAt = t.CreatedAt
            })
            .ToListAsync();
    }
}
