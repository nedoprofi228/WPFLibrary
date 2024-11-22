using System.Windows;
using CRUDLiblaryWPF.Core.Interfaces;
using CRUDLiblaryWPF.Core.Entities;
using Microsoft.Data.Sqlite;

namespace CRUDLiblaryWPF.Db;

public class UserDb: IUserDataBase
{
    private readonly string _connectionString;

    public UserDb(string connectionString)
    {
        _connectionString = connectionString;

        CheckTableExits();
    }
    public List<User> Get()
    {
        List<User> users = new List<User>();
        try
        {
            using (var db = new SqliteConnection(_connectionString))
            {
                db.Open();
                SqliteCommand command = new SqliteCommand( @"SELECT * FROM Users",db); // запрос для получения пользователей

                using (var reader = command.ExecuteReader()) // получает ответ из запроса
                {
                    if (reader.HasRows)
                        while (reader.Read()) // если ответ не пуст читает ответ
                            users.Add(new User() { Login = (string)reader["Login"], Password = (string)reader["Password"]});
                    else
                        MessageBox.Show("user not founded");
                }
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

        return users;
    }
    public User? GetUserById(int id)
    {
        User? userFromDb = null;
        try
        {
            using (var db = new SqliteConnection(_connectionString))
            {
                db.Open();
                SqliteCommand command = new SqliteCommand( @$"SELECT * FROM Users WHERE Id={id}",db); // запрос для получения пользователей

                using (var reader = command.ExecuteReader()) // получает данные о юзере из бд
                {
                    if (reader.HasRows)
                        while (reader.Read()) // если ответ не пуст читает ответ
                            userFromDb = new User() { Login = (string)reader["Login"], Password = (string)reader["Password"]};
                    MessageBox.Show("user not found");
                }
                
                command = new SqliteCommand( @$"SELECT * FROM UsersBook WHERE UserId={id}",db); // запрос для получения пользователей
                using (var reader = command.ExecuteReader()) // получает данные о юзере из бд
                {
                    if (reader.HasRows)
                        while (reader.Read()) // если ответ не пуст читает ответ
                            userFromDb?.Books.Add(new Book()
                                {
                                    Title = (string)reader["Title"],
                                    Author = (string)reader["Author"],
                                    Text = (string)reader["Text"]
                                });
                    MessageBox.Show("book not found");
                }
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

        return userFromDb;
    }

    public void AddUSer(User user)
    {
        try
        {
            using (var db = new SqliteConnection(_connectionString))
            {
                db.Open();
                SqliteCommand command = new SqliteCommand(@$"SELECT * FROM Users", db); // запрос для получения пользователей

                var reader = command.ExecuteReader(); // получает ответ из запроса
                    if (reader.HasRows)
                        while (reader.Read()) // если ответ не пуст читает ответ
                        {
                            var a = reader["Login"];
                            if ((string)reader["Login"] == user.Login) // если юзер есть, то возращает false
                            {
                                MessageBox.Show("User already exists");
                                return;
                            }
                        }
                    reader.Close();
                
                string sqlExpression =
                    $@"Insert Into Users (Login, Password) Values ('{user.Login}', '{user.Password}')"; // запрос для добавления юзера в базу
                command = new SqliteCommand(sqlExpression, db);
                command.ExecuteNonQuery();

                foreach (var book in user.Books)
                {
                    string sqlAddBookExpression =
                        @$"INSERT INTO Book (Title, Author,Text, UserId) VALUES ('{book.Title}','{book.Author}' ,'{book.Text}' ,'{user.Id}')";
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }

    public void UpdateUser(int id, User newUser)
    {
        try
        {
            using (var db = new SqliteConnection(_connectionString))
            {
                db.Open();
                
                string sqlExpression = $@"UPDATE Users SET Login={newUser.Login}, Password={newUser.Password}  WHERE Id={id}";

                var command = new SqliteCommand(sqlExpression, db);
                command.ExecuteNonQuery();

                foreach (var book in newUser.Books)
                {
                    command = new SqliteCommand(@$"SELECT * FROM UsersBooks WHERE Id={book.Id} AND UserId={id}", db);
                    var reader = command.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        sqlExpression = @$"INSERT INTO UsersBooks (Title, Author, Text, UserId) VALUES ('{book.Title}', '{book.Author}','{book.Text}', '{id}')";
                        command = new SqliteCommand(sqlExpression, db);
                        command.ExecuteNonQuery();
                    }
                    reader.Close();
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
                
                string createUserTableQuery = "CREATE TABLE IF NOT EXISTS Users (id INTEGER PRIMARY KEY, Login TEXT, Password TEXT)";
                string createUserBooksTableQuery = @"CREATE TABLE IF NOT EXISTS UsersBooks (
                    id INTEGER PRIMARY KEY, 
                    Title TEXT, 
                    Author TEXT, 
                    Text TEXT, 
                    UserId INTEGER, 
                    FOREIGN KEY(UserId) REFERENCES Users(Id))";
                var command = new SqliteCommand(createUserTableQuery, db);
                command.ExecuteNonQuery();
                command = new SqliteCommand(createUserBooksTableQuery, db);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
        
    }
}