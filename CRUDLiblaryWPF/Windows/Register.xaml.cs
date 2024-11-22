using System.Windows;
using CRUDLiblaryWPF.Core.Entities;
using CRUDLiblaryWPF.Core.Interfaces;

namespace CRUDLiblaryWPF.Windows;

public partial class Register : Window
{
    IUserDataBase _userDbService;
    IBookDataBase _bookDbService;
    
    public Register(IUserDataBase userDbService, IBookDataBase bookDbService)
    {
        _userDbService = userDbService;
        _bookDbService = bookDbService;
        InitializeComponent();
    }

    private void SaveBtn_OnClick(object sender, RoutedEventArgs e)
    {
        if (_userDbService.Get().FirstOrDefault(a => a.Login == LoginTextBox.Text) == null)
        {
            User user = new User
            {
                Login = LoginTextBox.Text,
                Password = PasswordTextBox.Text,
                Books = new List<Book>()
            };
        
            _userDbService.AddUSer(user);
            CurrentData.CurrentUser = user;
            CurrentData.isLoggedIn = true;
            
            SelectMenu selectMenu = new SelectMenu(_userDbService, _bookDbService);
            selectMenu.Show();
            this.Close();
        }

        else
        {
            MessageBox.Show("user already exists");
        }
    }

    private void ToSingUpDtn_OnClick(object sender, RoutedEventArgs e)
    {
        Login loginWindow = new Login(_userDbService, _bookDbService);
        loginWindow.Show();
        this.Close();
    }
}