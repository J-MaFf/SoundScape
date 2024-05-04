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


        //testSongController();

        //testAlbumController();

        testUserController();




        // Wait for user to end program
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();

    }

    public static void testSongController()
    {
        SongController songController = new();
        // Test all methods for songController:
        songController.ListSongsByArtist("red hot chili peppers");
        songController.ListSongsByAlbum("back in black");
        songController.ListSongsByName("Back in black");
        songController.ListSongsByDanceability(.466);
    }

    public static void testAlbumController()
    {
        AlbumController albumController = new();

        // Test all methods for albumController
        albumController.ListAlbumsByName("2014 Forest Hills Drive");
        albumController.ListAlbumsByArtist("J. Cole");

    }

    public static void testUserController()
    {
        UserController userController = new();

        // Test all methods for userController
        userController.ListAllUsers();
        userController.CreateNewUser("joey", "1234");
        userController.GetUser("joey");
        userController.DeleteUser("joey");
    }
}
