namespace CRUDLiblaryWPF.Core.Entities;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; } = String.Empty;
    public string Password { get; set; } = String.Empty;
    public List<Book> Books { get; set; } = [];
}