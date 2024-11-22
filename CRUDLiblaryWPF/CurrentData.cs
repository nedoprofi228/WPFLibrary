using CRUDLiblaryWPF.Core.Entities;

namespace CRUDLiblaryWPF;

public static class CurrentData
{
    public static string ConnetionString { get; set; } = "Data Source=Test.db";
    public static User CurrentUser { get; set; }
    public static Book? selectedBook = null;
    public static bool isLoggedIn = false;
}