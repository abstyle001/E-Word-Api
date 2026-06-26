using E_Word_Api.Models;
using E_Word_Api.Repositories;
using E_Word_Api.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Word_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProgressController(ProgressRepository progressRepository)
{
    [HttpPost]
    [Authorize(Roles = RoleType.User)]
    public Task UpdateProgress([FromBody] Progress progress)
    {
        return progressRepository.UpdateProgress(progress.UserId, progress.BookId);
    }

    [HttpGet]
    [Route("{UserId}")]
    [Authorize(Roles = RoleType.User)]
    public Task<long> GetProgress([FromRoute] string UserId)
    {
        return progressRepository.GetProgress(UserId);
    }
}