using System.ComponentModel.DataAnnotations;

namespace E_Word_Api.Dtos;

public class WordDto
{
    [Required]
    public string English { get; set; }
    [Required]
    public string Chinese { get; set; }
    [Required]
    public string[] Options { get; set; }
}