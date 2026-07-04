using E_Word_Api.Datas;
using E_Word_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Word_Api.Repositories;

public class UserBookRepository(EWordDbContext db)
{
    // 查询用户所选词书
    public async Task<UserBook?> FetchUserBook(string userId) => await db.UserBooks.FirstOrDefaultAsync(ub => ub.UserId == userId);

    // 添加用户词书
    public async Task AddUserBook(UserBook userBook)
    {
        await db.UserBooks.AddAsync(userBook);
        await db.SaveChangesAsync();
    }

    // 用户切换词书
    public void UpdateUserBook(UserBook userBook)
    {
        db.UserBooks.Update(userBook);
        db.SaveChanges();
    }
}