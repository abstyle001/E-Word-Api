
using E_Word_Api.Datas;
using E_Word_Api.Models;

namespace E_Word_Api.Repositories;

public class UserWordRepository(EWordDbContext db)
{
    public virtual async Task AddUserWord(UserWord userWord)
    {
        await db.AddAsync(userWord);
        await db.SaveChangesAsync();
    }
}