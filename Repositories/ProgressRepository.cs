using E_Word_Api.Datas;
using Microsoft.EntityFrameworkCore;

namespace E_Word_Api.Repositories;

public class ProgressRepository(EWordDbContext db)
{
    public async Task UpdateProgress(string UserId, long BookId)
    {
        var user = await db.Users.FindAsync(UserId);
        if (user == null)
        {
            // throw exception for user not found
            return;
        }
        
        var progress = await db.Progresses.FirstOrDefaultAsync(p => p.UserId == UserId);
        if (progress != null)
        {
            progress.BookId = BookId;
        }
        else
        {
            db.Progresses.Add(new Models.Progress
            {
                UserId = UserId,
                BookId = BookId
            });
        }
        await db.SaveChangesAsync();
    }

    public async Task<long> GetProgress(string UserId)
    {
        var progress = await db.Progresses.FirstOrDefaultAsync(p => p.UserId.Equals(UserId));
        if (progress == null)
        {
            throw new BizException("无此用户进度信息", statusCode: 500);
        }
        return progress.BookId;
    }
}