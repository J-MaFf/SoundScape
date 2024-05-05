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
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();

    }

    public static void TestSongController()
    {
        SongController songController = new();
        // Test all methods for songController:
        songController.GetSongsByArtist("red hot chili peppers");
        songController.GetSongsByAlbum("back in black");
        songController.GetSongsByName("Back in black");
        songController.GetSongsByDanceability(.466);
    }

    public static void TestAlbumController()
    {
        AlbumController albumController = new();

        // Test all methods for albumController
        albumController.ListAlbumsByName("2014 Forest Hills Drive");
        albumController.ListAlbumsByArtist("J. Cole");

    }

    public static void TestUserController()
    {
        UserController userController = new();

        // Test all methods for userController
        userController.GetAllUsers();
        userController.CreateNewUser("joey", "1234");
        userController.GetUser("joey");
        userController.DeleteUser("joey");
    }

    public static bool TestPlaylistController()
    {
        PlaylistController playlistController = new();
        SongController songController = new();
        UserController userController = new();

        var playlist = playlistController.GetPlaylistsByUser("joey")[0];
        playlistController.DeletePlaylist(playlist.PlaylistId);

        userController.CreateNewUser("joey", "1234");

        // Test all methods for playlistController
        playlistController.GetPlaylistsByUser("joey");

        // Create a new playlist
        var myPlaylist = playlistController.CreatePlaylist("joey", "My Playlist", "This is my playlist");

        // Get the playlist we just created
        var shouldBeSamePlaylist = playlistController.GetPlaylistByNameAndUser("My Playlist", "joey");

        if (myPlaylist != null && myPlaylist == shouldBeSamePlaylist)
        {
            Console.WriteLine("Playlist was created and retrieved successfully");
        }
        else
        {
            Console.WriteLine("Playlist was not created");
            return false;
        }
        // Get a song and add it to the playlist
        var song = songController.GetSongsByName("Back in black")[0]; // Get the first song in the list
        playlistController.AddSongToPlaylist(myPlaylist.PlaylistId, song.TrackId);
        var anotherSong = songController.GetSongsByName("Californication")[0];
        playlistController = new();
        playlistController.AddSongToPlaylist(myPlaylist.PlaylistId, anotherSong.TrackId);

        // View the songs in the playlist
        var playlistSongs = playlistController.GetPlaylistSongs(myPlaylist.PlaylistId);

        playlistSongs.ForEach(ps => Console.WriteLine(ps.TrackId));

        // Remove a song from the playlist
        playlistController.RemoveSongFromPlaylist(myPlaylist.PlaylistId, song.TrackId);

        // View the songs in the playlist
        playlistSongs = playlistController.GetPlaylistSongs(myPlaylist.PlaylistId);

        playlistSongs.ForEach(ps => Console.WriteLine(ps.TrackId, ps.Order));

        // Delete the playlist (will also delete the playlist songs)
        playlistController.DeletePlaylist(myPlaylist.PlaylistId);

        return true;




    }
}
