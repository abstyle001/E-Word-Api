using E_Word_Api.Datas;
using E_Word_Api.Dtos;
using Microsoft.EntityFrameworkCore;

namespace E_Word_Api.Repositories;

public class CET6BookRepository(EWordDbContext db)
{
    public async Task<List<Cet6BookDto>> GetPage(int pageNumber, int pageSize)
    {
        return await db.Cet6Books
            .OrderBy(b => b.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(b => new Cet6BookDto
            {
                Id = b.Id,
                Word = b.Word,
                Translate = b.Translate,
                DistractorWord1 = b.DistractorWord1,
                DistractorTranslate1 = b.DistractorTranslate1,
                DistractorWord2 = b.DistractorWord2,
                DistractorTranslate2 = b.DistractorTranslate2,
                DistractorWord3 = b.DistractorWord3,
                DistractorTranslate3 = b.DistractorTranslate3
            })
            .ToListAsync();
    }
}
