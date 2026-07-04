using E_Word_Api.Dtos;
using E_Word_Api.Models;
using E_Word_Api.Repositories;
using E_Word_Api.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Word_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WordController(WordRepository wordRepository,
    CET6BookRepository cet6BookRepository,
    UserBookRepository userBookRepository,
    UserSessionRepository userSessionRepository) : ControllerBase
{
    [HttpGet]
    // [Authorize(Roles = RoleType.User)]
    public async Task<ActionResult<List<Word>>> GetWords()
    {
        return await wordRepository.GetWords();
    }

    [HttpPost]
    [Authorize(Roles = RoleType.User)]
    public async Task<ActionResult<String>> AddWordRange([FromBody] List<WordDto> words)
    {
        return await wordRepository.AddWordRange(words);
    }

    /**
     *　分配新词
     */
    [HttpGet]
    [Route("new")]
    public async Task<List<CET6Book>> GetNewWords([FromQuery] int number, [FromQuery] string userId)
    {
        // 先查到用户所选中的词数
        var userBook = await userBookRepository.FetchUserBook(userId);
        if (userBook == null)
        {
            throw new BizException("用户未选择词书");
        }
        if (userBook.BookName == "CET6")
        {
            // 查询缓存库中是否有没背完的单词
            var unFinishedWords = await userSessionRepository.GetSessions(userId);
            if (unFinishedWords != null && unFinishedWords.Any())
            {
                var ids = unFinishedWords
                    .Select(w => w.BookId)
                    .ToList();
                if (ids != null && ids.Any())
                {
                    // 还有没背完的单词
                    return await cet6BookRepository.GetWordsByIds(ids);
                }
            }
            var words = await cet6BookRepository.SelectNewWords(number, userId);
            var sessions = words
                .Select(w => new UserSession
                {
                    UserId = userId,
                    BookId = w.Id
                })
                .ToList();
            // 添加到缓存库中
            await userSessionRepository.AddSessionWord(sessions);
            return words;
        }
        else
        {
            throw new BizException("词书未启用");
        }
    }

    /**
     * 切换词书
     */
    [HttpPost]
    [Route("switch-book")]
    public async Task SwitchBook(string userId, string bookName)
    {
        var userBook = await userBookRepository.FetchUserBook(userId);
        if (userBook == null)
        {
            userBook = new UserBook { UserId = userId, BookName = bookName };
            await userBookRepository.AddUserBook(userBook);
        }
        else
        {
            userBook.BookName = bookName;
            userBookRepository.UpdateUserBook(userBook);
        }
    }
}