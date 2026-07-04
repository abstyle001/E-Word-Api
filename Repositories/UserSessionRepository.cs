using E_Word_Api.Datas;
using E_Word_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Word_Api.Repositories;

public class UserSessionRepository(EWordDbContext db)
{
    // 添加用户的缓存单词
    public async Task AddSessionWord(List<UserSession> sessions)
    {
        await db.UserSessions.AddRangeAsync(sessions);
        await db.SaveChangesAsync();
    }

    // 获取用户缓存的单词
    public async Task<List<UserSession>> GetSessions(string userId) => 
        await db.UserSessions
            .Where(us => us.UserId == userId)
            .ToListAsync();

    // 删除缓存的单词
    public async Task DeleteSession(long id)
    {
        var userSession = await db.UserSessions.FindAsync(id);
        if (userSession != null)
        {
            db.UserSessions.Remove(userSession);
            await db.SaveChangesAsync();
        }
    }

    // 查询缓存单词
    public async Task<UserSession?> GetSession(string userId, long bookId) => 
        db.UserSessions
            .Where(us => us.UserId == userId && us.BookId == bookId)
            .FirstOrDefault();
}