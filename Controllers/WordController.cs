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
    UserSessionRepository userSessionRepository,
    UserWordRepository userWordRepository) : ControllerBase
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

    [HttpPost]
    [Route("learn")]
    public async Task<WordLearnResultDto> LearnWord([FromBody] WordLearnDto wordLearnDto)
    {
        // 查询出用户所选词书
        var userBook = await userBookRepository.FetchUserBook(wordLearnDto.UserId);
        if (userBook == null)
        {
            throw new BizException("用户未选择词书");
        }

        var userSession = await userSessionRepository.GetSession(wordLearnDto.UserId, wordLearnDto.BookId);
        if (userSession == null)
        {
            throw new BizException("该单词未缓存");
        }

        const int masteryThreshold = 3;
        userSession.TotalAttempts++;

        if (wordLearnDto.IsCorrect)
        {
            userSession.CorrectStreak++;
            if (userSession.CorrectStreak >= masteryThreshold)
            {
                // 连续正确达到阈值 → 掌握，从缓存移到已背词表
                await userSessionRepository.DeleteSession(userSession.Id);

                var userWord = new UserWord
                {
                    UserId = wordLearnDto.UserId,
                    WordId = wordLearnDto.BookId,
                    OriginBook = "CET6",
                    Status = "mastered",
                    Attempts = userSession.TotalAttempts,
                    MasteredAt = DateTime.UtcNow,
                    RepetitionCount = 0,
                    IntervalDays = 1,
                    NextReviewAt = DateTime.UtcNow.AddDays(1)
                };
                await userWordRepository.AddUserWord(userWord);

                return new WordLearnResultDto { Mastered = true, CurrentStreak = userSession.CorrectStreak };
            }
            else
            {
                // 正确但未达阈值 → 保留在缓存中
                await userSessionRepository.UpdateSession(userSession);
                return new WordLearnResultDto { Mastered = false, CurrentStreak = userSession.CorrectStreak };
            }
        }
        else
        {
            // 答错 → 连续正确次数归零，保留在缓存中
            userSession.CorrectStreak = 0;
            await userSessionRepository.UpdateSession(userSession);
            return new WordLearnResultDto { Mastered = false, CurrentStreak = 0 };
        }
    }

    /// <summary>
    /// 获取到期需要复习的旧词
    /// </summary>
    [HttpGet]
    [Route("review")]
    public async Task<List<QuizWordDto>> GetReviewWords([FromQuery] int number, [FromQuery] string userId)
    {
        var userWords = await userWordRepository.GetDueReviewWords(userId, number);
        if (userWords == null || !userWords.Any())
            return new List<QuizWordDto>();

        var wordIds = userWords.Select(uw => uw.WordId).ToList();
        var books = await cet6BookRepository.GetWordsByIds(wordIds);

        // 保持与 DueReviewWords 相同的顺序（按 NextReviewAt ASC）
        var bookDict = books.ToDictionary(b => b.Id);
        var result = new List<QuizWordDto>();
        foreach (var uw in userWords)
        {
            if (bookDict.TryGetValue(uw.WordId, out var book))
            {
                result.Add(new QuizWordDto
                {
                    Id = book.Id,
                    Word = book.Word,
                    Translate = book.Translate,
                    DistractorWord1 = book.DistractorWord1,
                    DistractorTranslate1 = book.DistractorTranslate1,
                    DistractorWord2 = book.DistractorWord2,
                    DistractorTranslate2 = book.DistractorTranslate2,
                    DistractorWord3 = book.DistractorWord3,
                    DistractorTranslate3 = book.DistractorTranslate3,
                    IsReview = true
                });
            }
        }
        return result;
    }

    /// <summary>
    /// 提交复习结果
    /// </summary>
    [HttpPost]
    [Route("review")]
    public async Task<WordReviewResultDto> ReviewWord([FromBody] WordReviewDto dto)
    {
        var userWord = await userWordRepository.GetByUserIdAndWordId(dto.UserId, dto.BookId)
            ?? throw new BizException("该单词未在学习记录中");

        userWord.LastReviewedAt = DateTime.UtcNow;

        if (dto.IsCorrect)
        {
            userWord.RepetitionCount++;
        }
        else
        {
            userWord.RepetitionCount = Math.Max(0, userWord.RepetitionCount - 1);
        }

        userWord.IntervalDays = GetIntervalDays(userWord.RepetitionCount);
        userWord.NextReviewAt = DateTime.UtcNow.AddDays(userWord.IntervalDays);

        await userWordRepository.UpdateUserWord(userWord);

        return new WordReviewResultDto
        {
            Correct = dto.IsCorrect,
            RepetitionCount = userWord.RepetitionCount,
            NextReviewAt = userWord.NextReviewAt.Value,
            IntervalDays = userWord.IntervalDays
        };
    }

    /// <summary>
    /// 获取待复习词数量
    /// </summary>
    [HttpGet]
    [Route("review/count")]
    public async Task<int> GetReviewCount([FromQuery] string userId)
        => await userWordRepository.CountDueReviews(userId);

    private static int GetIntervalDays(int repetitionCount) => repetitionCount switch
    {
        0 => 1,
        1 => 3,
        2 => 7,
        3 => 30,
        4 => 90,
        _ => 180
    };

    /**
     * 切换词书
     */
    [HttpPost]
    [Route("switch-book")]
    public async Task SwitchBook([FromBody] UserBookDto userBookDto)
    {
        var userBook = await userBookRepository.FetchUserBook(userBookDto.UserId);
        if (userBook == null)
        {
            userBook = new UserBook { UserId = userBookDto.UserId, BookName = userBookDto.BookName };
            await userBookRepository.AddUserBook(userBook);
        }
        else
        {
            userBook.BookName = userBookDto.BookName;
            userBookRepository.UpdateUserBook(userBook);
        }
    }

    /**
     * 查看用户所选词书
     */
    [HttpGet]
    [Route("check-book")]
    public async Task<UserBook> CheckUserBook([FromQuery] string userId)
    {
        var userBook = await userBookRepository.FetchUserBook(userId);
        if (userBook == null)
        {
            throw new BizException("未选择词书");
        }
        return userBook;
    }
}
