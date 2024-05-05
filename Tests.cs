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
        // Console.WriteLine("fearless search results: ");
        // foreach (var song in fearless) Console.WriteLine(song.Trackname);
        // Console.WriteLine("\n\n");
        
        // Console.WriteLine("rhcp search results: ");
        // foreach (var song in rhcp) Console.WriteLine(song.Trackname);
        // Console.WriteLine("\n\n");
        
        // Console.WriteLine("fearless sorted by duration: ");
        // foreach (var song in sortedByDuration) Console.WriteLine(song.Trackname);
        // Console.WriteLine("\n\n");

        // Console.WriteLine("rhcp sorted by danceability: ");
        // foreach (var song in sortedByDanceability) Console.WriteLine(song.Trackname);
        // Console.WriteLine("\n\n");

        // Console.WriteLine("fearless filtered by profanity: ");
        // foreach (var song in filteredByProfanity) Console.WriteLine(song.Trackname);
        // Console.WriteLine("\n\n");

        // Console.WriteLine("fearless filtered by genre: ");
        // foreach (var song in filteredByGenre) Console.WriteLine(song.Trackname);
        // Console.WriteLine("\n\n");

        return true;

       
    }

    public static bool TestAlbumController()
    {
        AlbumController albumController = new();

        // Test all methods for albumController
        var fearless = albumController.SearchString("fearless");
        var sortedByDuration = AlbumController.SortByDuration(fearless);
        var sortedByTotalSongs = AlbumController.SortByTotalSongs(fearless);

        // Print results
        // Console.WriteLine("fearless search results: ");
        // foreach (var album in fearless) Console.WriteLine(album.Name);
        // Console.WriteLine("\n\n");

        // Console.WriteLine("fearless sorted by duration: ");
        // foreach (var album in sortedByDuration) Console.WriteLine(album.Name);
        // Console.WriteLine("\n\n");

        // Console.WriteLine("fearless sorted by total songs: ");
        // foreach (var album in sortedByTotalSongs) Console.WriteLine(album.Name);
        // Console.WriteLine("\n\n");

        return true;

    }

    public static bool TestUserController()
    {
        UserController userController = new();

        // Test all methods for userController
        userController.CreateNewUser("joey", "1234");
        var user = userController.GetUser("joey");
        var anotherUser = userController.CreateNewUser("matthew", "5678");
        var users = userController.SearchString(""); // Search for all users
        var sortedByMinutes = UserController.SortByMinutes(users);

        userController.DeleteUser("joey");
        userController.DeleteUser("matthew");

        // Print results
        // Console.WriteLine("User joey: ");
        // Console.WriteLine(user.Username);
        // Console.WriteLine("\n\n");

        // Console.WriteLine("User matthew: ");
        // Console.WriteLine(anotherUser.Username);
        // Console.WriteLine("\n\n");

        // Console.WriteLine("All users: ");
        // foreach (var u in users) Console.WriteLine(u.Username);
        // Console.WriteLine("\n\n");

        // Console.WriteLine("Users sorted by minutes listened: ");
        // foreach (var u in sortedByMinutes) Console.WriteLine(u.Username);
        // Console.WriteLine("\n\n");

        return true;
    }

    public static bool TestPlaylistController()
    {
        PlaylistController playlistController = new();

        return true;

    }
}
    
    