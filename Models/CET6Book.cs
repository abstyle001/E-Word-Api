using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Word_Api.Models;

[Table("CET6Books")]
public class CET6Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string Word { get; set; }
    public string Translate { get; set; }
    public string DistractorWord1 { get; set; }
    public string DistractorTranslate1 { get; set; }
    public string DistractorWord2 { get; set; }
    public string DistractorTranslate2 { get; set; }
    public string DistractorWord3 { get; set; }
    public string DistractorTranslate3 { get; set; }
}
