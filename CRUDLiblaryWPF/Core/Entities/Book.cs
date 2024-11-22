using System.ComponentModel.DataAnnotations;

namespace CRUDLiblaryWPF.Core.Entities;

public class Book
{
    [Key]
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author {get; set;}  = string.Empty;
    public string Text {get; set;} = string.Empty;
}