using E_Word_Api.Dtos;
using E_Word_Api.Repositories;
using E_Word_Api.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Word_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class StatsController(
    CET6BookRepository cet6BookRepository,
    UserBookRepository userBookRepository,
    UserWordRepository userWordRepository) : ControllerBase
{
    /// <summary>获取用户学习进度统计（总词数 / 已掌握 / 待复习）</summary>
    [HttpGet("{userId}")]
    [Authorize(Roles = RoleType.User)]
    public async Task<UserStatsDto> GetStats([FromRoute] string userId)
    {
        var userBook = await userBookRepository.FetchUserBook(userId);
        var bookName = userBook?.BookName ?? "CET6";

        var totalWords = await cet6BookRepository.CountAsync();
        var wordsMastered = await userWordRepository.CountMasteredAsync(userId, bookName);
        var wordsDueForReview = await userWordRepository.CountDueReviews(userId);

        return new UserStatsDto
        {
            TotalWords = totalWords,
            WordsMastered = wordsMastered,
            WordsDueForReview = wordsDueForReview
        };
    }

    /// <summary>重置学习进度（清空用户已掌握的单词记录）</summary>
    [HttpPost("reset")]
    [Authorize(Roles = RoleType.User)]
    public async Task<IActionResult> ResetStats([FromBody] string userId)
    {
        await userWordRepository.DeleteAllByUserAsync(userId);
        return Ok();
    }
}
