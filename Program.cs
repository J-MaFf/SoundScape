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

        /// Testing Query Controller
        QueryController queryController = new();
        // QueryController.ListSongsByArtist();
        // QueryController.ListAlbumsBySong("Hello");
        //QueryController.ListSongsByDanceablity();
        QueryController.ListSongsBy(s => s.Artists == "Red Hot Chili Peppers");

        // Wait for user to end program
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();

    }
}