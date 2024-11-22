using System.Windows;
using CRUDLiblaryWPF.Core.Entities;
using CRUDLiblaryWPF.Core.Interfaces;
using Microsoft.Data.Sqlite;

namespace CRUDLiblaryWPF.Db;

public class BookDb: IBookDataBase
{
    private readonly string _connectionString;

    public BookDb(string connectionString)
    {
        _connectionString = connectionString;
        
        CheckTableExits();
    }
    
    public List<Book> GetBooks()
    {
        List<Book> books = new List<Book>();
        try
        {
            using (var db = new SqliteConnection(_connectionString))
            {
                db.Open();
                SqliteCommand
                    command = new SqliteCommand(@"SELECT * FROM Books", db); // запрос для получения пользователей

                var reader = command.ExecuteReader(); // получает ответ из запроса
                if (reader.HasRows)
                    while (reader.Read()) // если ответ не пуст читает ответ
                        books.Add(new Book()
                        {
                            Id = (long)reader["Id"], 
                            Author = (string)reader["Author"], 
                            Title = (string)reader["Title"],
                            Text = (string)reader["Text"]
                        });

            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

        return books;
    }

    public Book GetBookById(int id)
    {
        try
        {
            using (var db = new SqliteConnection(_connectionString))
            {
                db.Open();
            
                string sql = $@"SELECT * FROM Books WHERE Id = {id}";
                var command = new SqliteCommand(sql, db);
            
                using (var reader = command.ExecuteReader())
                    if (reader.Read())
                        return new Book()
                        {
                            Id = (long)reader["Id"],
                            Title = (string)reader["Title"],
                            Author = (string)reader["Author"],
                            Text = (string)reader["Text"],
                        };
                    else
                        throw new Exception("book not found");
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
            throw;
        }
       
    }

    public void AddBook(Book book)
    {
        try
        {
            using (var db = new SqliteConnection(_connectionString))
            {
                db.Open();
                SqliteCommand command = new SqliteCommand(@$"SELECT * FROM Books WHERE Id={book.Id}", db); // запрос для получения книг

                using (var reader = command.ExecuteReader()) // получает ответ из запроса
                {
                    if (reader.HasRows)
                        throw new Exception("Book already exists");
                }
                
                string sqlExpression =
                    $@"Insert Into Books (Title, Author, Text) Values ('{book.Title}', '{book.Author}', '{book.Text}')"; // запрос для добавления книги в базу
                command = new SqliteCommand(sqlExpression, db);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }

    public void DeleteBook(Book book)
    {
        try
        {
            using (var db = new SqliteConnection(_connectionString))
            {
                db.Open();
                
                string sql = $"DELETE FROM Books WHERE Id = {book.Id}";
                var command = new SqliteCommand(sql, db);
                int rowsAffected = command.ExecuteNonQuery();
                
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Book deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }
    private void CheckTableExits()
    {
        try
        {
            using (var db = new SqliteConnection(_connectionString))
            {
                db.Open();
                
                string createTableQuery = "CREATE TABLE IF NOT EXISTS Books (id INTEGER PRIMARY KEY, Title TEXT, Author TEXT, Text TEXT)";
                var command = new SqliteCommand(createTableQuery, db);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
            throw;
        }
        
    }
}