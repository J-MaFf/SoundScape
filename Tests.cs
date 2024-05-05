using SoundScape.Controllers;
namespace SoundScape;

class Tests {
    public static bool TestSongController()
    {
        SongController songController = new();
        // Test all methods for songController:
        var fearless = songController.SearchString("fearless");
        var rhcp = songController.SearchString("Red Hot Chili Peppers");
        var sortedByDuration = SongController.SortByDuration(fearless);
        var sortedByDanceability = SongController.SortByDanceability(rhcp);
        var filteredByProfanity = SongController.FilterByProfanity(fearless);
        var filteredByGenre = SongController.FilterByGenre(fearless, "pop");

        // Print results
        Console.WriteLine("fearless search results: ");
        foreach (var song in fearless) Console.WriteLine(song.Trackname);
        Console.WriteLine("\n\n");
        
        Console.WriteLine("rhcp search results: ");
        foreach (var song in rhcp) Console.WriteLine(song.Trackname);
        Console.WriteLine("\n\n");
        
        Console.WriteLine("fearless sorted by duration: ");
        foreach (var song in sortedByDuration) Console.WriteLine(song.Trackname);
        Console.WriteLine("\n\n");

        Console.WriteLine("rhcp sorted by danceability: ");
        foreach (var song in sortedByDanceability) Console.WriteLine(song.Trackname);
        Console.WriteLine("\n\n");

        Console.WriteLine("fearless filtered by profanity: ");
        foreach (var song in filteredByProfanity) Console.WriteLine(song.Trackname);
        Console.WriteLine("\n\n");

        Console.WriteLine("fearless filtered by genre: ");
        foreach (var song in filteredByGenre) Console.WriteLine(song.Trackname);
        Console.WriteLine("\n\n");

        return true;

       
    }

    public static bool TestAlbumController()
    {
        AlbumController albumController = new();

        // Test all methods for albumController
       return true;

    }

    public static bool TestUserController()
    {
        UserController userController = new();

        // Test all methods for userController
        userController.CreateNewUser("joey", "1234");
        userController.GetUser("joey");
        userController.DeleteUser("joey");

        return true;
    }

    public static bool TestPlaylistController()
    {
        PlaylistController playlistController = new();

        return true;

    }
}
    
    