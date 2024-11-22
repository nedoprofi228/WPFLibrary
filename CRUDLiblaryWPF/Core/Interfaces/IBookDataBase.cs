using CRUDLiblaryWPF.Core.Entities;

namespace CRUDLiblaryWPF.Core.Interfaces;

public interface IBookDataBase
{
    public List<Book> GetBooks();
    public Book GetBookById(int id);
    public void AddBook(Book book);
    public void DeleteBook(Book book);
}