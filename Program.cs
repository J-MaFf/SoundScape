namespace SoundScape;
using System.Threading;

static partial class Program
{
    [System.Runtime.InteropServices.LibraryImport("kernel32.dll")]
    [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
    private static partial bool AllocConsole();
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    // [STAThread]
    static void Main()
    {
        // AllocConsole();
        // // To customize application configuration such as set high DPI settings or default font,
        // // see https://aka.ms/applicationconfiguration.
        // ApplicationConfiguration.Initialize();
        // Application.Run(new Form1());


        //TestSongController();

        //TestAlbumController();

        //TestUserController();

        TestPlaylistController();




        // Wait for user to end program
        //Console.WriteLine("Press any key to exit.");
        //Console.Read();

    }

    public static void TestSongController()
    {
        SongController songController = new();
        // Test all methods for songController:
        
    }

    public static void TestAlbumController()
    {
        AlbumController albumController = new();

        // Test all methods for albumController
        

    }

    public static void TestUserController()
    {
        UserController userController = new();

        // Test all methods for userController
        userController.SearchString(""); // Equivalant to GetAllUsers() if string is empty

        userController.CreateNewUser("joey", "1234");
        userController.GetUser("joey");
        userController.DeleteUser("joey");
    }

    public static void TestPlaylistController()
    {
        
    }
}
