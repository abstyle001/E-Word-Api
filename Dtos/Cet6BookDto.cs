namespace E_Word_Api.Dtos;

public class Cet6BookDto
{
    public long Id { get; set; }
    public string Word { get; set; } = string.Empty;
    public string Translate { get; set; } = string.Empty;
    public string DistractorWord1 { get; set; } = string.Empty;
    public string DistractorTranslate1 { get; set; } = string.Empty;
    public string DistractorWord2 { get; set; } = string.Empty;
    public string DistractorTranslate2 { get; set; } = string.Empty;
    public string DistractorWord3 { get; set; } = string.Empty;
    public string DistractorTranslate3 { get; set; } = string.Empty;
}
