using System.Windows;
using System.Windows.Controls;
using CRUDLiblaryWPF.Core.Entities;
using CRUDLiblaryWPF.Core.Interfaces;

namespace CRUDLiblaryWPF.Windows;

public partial class AddBook : Window
{
    private IBookDataBase _db;
    private TextBlock error = new TextBlock();
    
    public AddBook(IBookDataBase db)
    {
        _db = db;
        InitializeComponent();
        
        error.HorizontalAlignment = HorizontalAlignment.Center;
        Grid.SetRow(error, 7);
        Grid.SetColumn(error, 0);
    }

    private void AddBookBtn_Click(object sender, RoutedEventArgs e)
    {
        string? title = TitleTextBox.Text;
        string? Author = AuthorTextBox.Text;
        string? Text = TextTextBox.Text;

        bool isValid = false;
        
        if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(Author) && string.IsNullOrEmpty(Text))
            error.Text = "заполните все поля";
        else
            isValid = true;

        if (isValid)
        {
            try
            {
                _db.AddBook(new Book() { Title = title, Author = Author, Text = Text });
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            this.Close();
        }
    }
}