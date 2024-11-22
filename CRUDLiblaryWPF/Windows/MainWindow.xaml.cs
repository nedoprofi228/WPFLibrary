using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CRUDLiblaryWPF.Db;
using CRUDLiblaryWPF.Windows;

namespace CRUDLiblaryWPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        UserDb userDbService = new UserDb(CurrentData.ConnetionString);
        BookDb bookDbService = new BookDb(CurrentData.ConnetionString);
        Login loginWindow = new Login(userDbService, bookDbService);
        loginWindow.Show();
        this.Close();
    }
}