using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using CRUDLiblaryWPF.Core.Entities;
using CRUDLiblaryWPF.Core.Interfaces;

namespace CRUDLiblaryWPF.Windows;

public partial class SelectMenu : Window
{
    private readonly IUserDataBase _dbUser;
    private readonly IBookDataBase _dbBook;
    
    private BindingList<Book> books = new();

    public SelectMenu(IUserDataBase userDataBase, IBookDataBase bookDataBase)
    {
        InitializeComponent();
        
        _dbUser = userDataBase;
        _dbBook = bookDataBase;
        
        BooksList.ItemsSource = GetBooks();
        this.KeyDown += OnKeyDown;
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        if ((e.Key == Key.Delete) && CurrentData.selectedBook != null)
        {
            _dbBook.DeleteBook(CurrentData.selectedBook);
            BooksList.ItemsSource = GetBooks();
        }
    }
    private void BookList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if (BooksList.SelectedItem is Book selectedBook)
        {
            BookInfo.HorizontalAlignment = HorizontalAlignment.Left;
            BookInfo.Text = $"Название: {selectedBook.Title}\nАвтор: {selectedBook.Author}";
            
            BookText.HorizontalAlignment = HorizontalAlignment.Center;
            BookText.VerticalAlignment = VerticalAlignment.Top;
            BookText.Text = selectedBook.Text;
            CurrentData.selectedBook = selectedBook;
        }

        
    }

    private void AddBookBtn_OnClick(object sender, RoutedEventArgs e)
    {
        AddBook addBookWindow = new AddBook(_dbBook);
        addBookWindow.Show();
        addBookWindow.Closed += ChildWindow_Closed;
        this.Hide();
    }

    private void ChildWindow_Closed(object sender, EventArgs e)
    {
        BooksList.ItemsSource = GetBooks();
        this.Show();
    }

    private BindingList<Book> GetBooks()
    {
        BindingList<Book> books = [];
        
        if(IsFavoriteCheckBox.IsChecked == false) // если обычный каталог
            foreach (Book book in _dbBook.GetBooks())
                books.Add(book);
        else                                      // если выбраны любимые книги
            foreach (Book book in CurrentData.CurrentUser.Books)
                books.Add(book);

        return books;
    }

    private void DeleteBookBtn_OnClick(object sender, RoutedEventArgs e)
    {
        if (CurrentData.selectedBook != null)
        {
            _dbBook.DeleteBook(CurrentData.selectedBook);
            BooksList.ItemsSource = GetBooks();
        }
    }

    private void AddInFavoritesBtn_OnClick(object sender, RoutedEventArgs e)
    {
        if (CurrentData.selectedBook != null)
        {
            User newUser = new User()
            {
                Login = CurrentData.CurrentUser.Login,
                Password = CurrentData.CurrentUser.Password,
                Books = CurrentData.CurrentUser.Books
            };
            
            newUser.Books.Add(CurrentData.selectedBook);
            
            _dbUser.UpdateUser(CurrentData.CurrentUser.Id, newUser);
        }
    }

    private void favoritesBtn_OnClick(object sender, RoutedEventArgs e)
    {
        BooksList.ItemsSource = GetBooks();
    }
}