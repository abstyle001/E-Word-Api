using E_Word_Api.Datas;
using E_Word_Api.Dtos;
using E_Word_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Word_Api.Repositories;

public class WordRepository(
    EWordDbContext db)
{
    public async Task<List<Word>> GetWords()
    {
        return await db.Words.ToListAsync();
    }

    public async Task<String> AddWordRange(List<WordDto> words)
    {
        await db.Words.AddRangeAsync(words.Select(w => new Word
        {
            English = w.English,
            Chinese = w.Chinese,
            Options = w.Options
        }).ToList());
        await db.SaveChangesAsync();
        return "Word input successful";
    }
}