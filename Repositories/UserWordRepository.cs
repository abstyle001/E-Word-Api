
using E_Word_Api.Datas;
using E_Word_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Word_Api.Repositories;

public class UserWordRepository(EWordDbContext db)
{
    public virtual async Task AddUserWord(UserWord userWord)
    {
        await db.AddAsync(userWord);
        await db.SaveChangesAsync();
    }

    /// <summary>获取到期需要复习的单词</summary>
    public virtual async Task<List<UserWord>> GetDueReviewWords(string userId, int limit)
    {
        var now = DateTime.UtcNow;
        return await db.UserWords
            .Where(uw => uw.UserId == userId && uw.NextReviewAt <= now)
            .OrderBy(uw => uw.NextReviewAt)
            .Take(limit)
            .ToListAsync();
    }

    /// <summary>按用户+单词ID查找记录</summary>
    public virtual async Task<UserWord?> GetByUserIdAndWordId(string userId, long wordId) =>
        await db.UserWords
            .FirstOrDefaultAsync(uw => uw.UserId == userId && uw.WordId == wordId);

    /// <summary>更新复习状态</summary>
    public virtual async Task UpdateUserWord(UserWord userWord)
    {
        db.UserWords.Update(userWord);
        await db.SaveChangesAsync();
    }

    /// <summary>获取到期复习单词总数</summary>
    public virtual async Task<int> CountDueReviews(string userId)
    {
        var now = DateTime.UtcNow;
        return await db.UserWords
            .CountAsync(uw => uw.UserId == userId && uw.NextReviewAt <= now);
    }
}
