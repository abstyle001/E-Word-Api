using E_Word_Api.Dtos;
using E_Word_Api.Models;
using E_Word_Api.Repositories;
using E_Word_Api.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Word_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WordController(WordRepository wordRepository) : ControllerBase
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
}