using E_Word_Api.Dtos;
using E_Word_Api.Models;
using E_Word_Api.Repositories;
using E_Word_Api.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Word_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CET6BookController(CET6BookRepository cet6BookRepository) : ControllerBase
{
    [HttpGet]
    [Route("page")]
    [Authorize(Roles = RoleType.User)]
    public async Task<List<Cet6BookDto>> GetPage([FromQuery] int number, [FromQuery] int size)
    {
        return await cet6BookRepository.GetPage(number, size);
    }

    [HttpGet]
    [Route("new")]
    public async Task<List<CET6Book>> GetNewWords([FromQuery] int number, [FromQuery] string userId)
    {
        return await cet6BookRepository.SelectNewWords(number, userId);
    }
}
