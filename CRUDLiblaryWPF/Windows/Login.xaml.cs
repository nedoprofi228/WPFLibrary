using System.Windows;
using CRUDLiblaryWPF.Core.Entities;
using CRUDLiblaryWPF.Core.Interfaces;
using CRUDLiblaryWPF.Windows;

namespace CRUDLiblaryWPF;

public partial class Login : Window
{
    private IUserDataBase _userDbService;
    private IBookDataBase _bookDbService;
    public Login(IUserDataBase userDbService, IBookDataBase bookDbService)
    {
        InitializeComponent();
        _userDbService = userDbService;
        _bookDbService = bookDbService;
    }

    private void RegisterBtn_OnClick(object sender, RoutedEventArgs e)
    {
        Register registerWindow = new Register(_userDbService, _bookDbService);
        registerWindow.Show();
        this.Close();
    }

    private void LoginBtn_OnClick(object sender, RoutedEventArgs e)
    {
        if (_userDbService.Get().FirstOrDefault(a => a.Login == LoginEl.Text && a.Password == PasswordEl.Password) != null)
        {
            User user = new User
            {
                Login = LoginEl.Text,
                Password = PasswordEl.Password
            };
            
            CurrentData.CurrentUser = user;
            CurrentData.isLoggedIn = true;
            
            SelectMenu selectMenuWindow = new SelectMenu(_userDbService, _bookDbService);
            selectMenuWindow.Show();
            this.Close();
        }
    }
}