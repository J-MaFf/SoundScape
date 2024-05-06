namespace SoundScape;

using COMPSCI366.Models;
using System.Threading;

static partial class Program
{
    [System.Runtime.InteropServices.LibraryImport("kernel32.dll")]
    [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
    private static partial bool AllocConsole();
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        AllocConsole();
        // // To customize application configuration such as set high DPI settings or default font,
        // // see https://aka.ms/applicationconfiguration.

        //AlbumController aC  = new AlbumController();
        //var albums = aC.SearchString("");
        //foreach( var album in albums )
        //{
        //    foreach (var song in album.Songs )
        //    {
        //        Console.WriteLine(song.Trackname);
        //    }
        //}

        PlaylistController pC = new PlaylistController();
        //pC.EraseAllPlaylistsAndPlaylistSongs();

        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}
