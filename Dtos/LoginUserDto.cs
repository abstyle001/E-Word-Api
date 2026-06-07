using System.ComponentModel.DataAnnotations;

namespace E_Word_Api.Dtos;

public class LoginUserDto
{
    [Required] [EmailAddress] public string Email { get; set; } = string.Empty;
    [Required] public string Password { get; set; } = string.Empty;
}