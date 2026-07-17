namespace E_Word_Api.Dtos;

/// <summary>
/// 复习单词返回 DTO（与 CET6Book 数据对齐，附加 IsReview 标记）
/// </summary>
public class QuizWordDto
{
    public long Id { get; set; }
    public string Word { get; set; }
    public string Translate { get; set; }
    public string DistractorWord1 { get; set; }
    public string DistractorTranslate1 { get; set; }
    public string DistractorWord2 { get; set; }
    public string DistractorTranslate2 { get; set; }
    public string DistractorWord3 { get; set; }
    public string DistractorTranslate3 { get; set; }
    /// <summary>是否为复习词（非新词）</summary>
    public bool IsReview { get; set; }
}
