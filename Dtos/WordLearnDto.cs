namespace E_Word_Api.Dtos;

public class WordLearnDto
{
    public string UserId { get; set; }
    public long BookId { get; set; }
    /// <summary>本次答题是否正确</summary>
    public bool IsCorrect { get; set; }
}
