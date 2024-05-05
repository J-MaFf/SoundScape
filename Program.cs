namespace SoundScape;
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
        AllocConsole();
        // // To customize application configuration such as set high DPI settings or default font,
        // // see https://aka.ms/applicationconfiguration.
        // ApplicationConfiguration.Initialize();
        // Application.Run(new Form1());

        // Wait for user to end program
        Console.Write("Press enter key to exit. ");
        Console.Read();

    }

    public static void TestControllers()
    {
        var t = new Tests();
        bool pass = true;
        while (pass)
        {
            pass = t.TestSongController();
            Console.WriteLine("SongController test passed: " + pass);
            pass = t.TestAlbumController();
            Console.WriteLine("AlbumController test passed: " + pass);
            pass = t.TestUserController();
            Console.WriteLine("UserController test passed: " + pass);
            pass = t.TestPlaylistController();
            Console.WriteLine("PlaylistController test passed: " + pass);
        }
    }

}
