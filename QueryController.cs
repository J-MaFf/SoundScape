using SoundScape.Models;

public class QueryController
{
    public static void ListSongsByArtist()
    {
        using CompsciprojectContext context = new();
        string artistName = "Red Hot Chili Peppers";

        var songs = context.Songs
            .Where(s => s.Artists == artistName) // Filter songs by artist name
            .ToList(); // Execute the query and get the results as a List


        ///
        /// Getting a ton of duplicates? Issue with relationships?
        ///
        // foreach (var song in songs)
        // {
        //     Console.WriteLine(song.TrackName); // Print the name of the song
        // }

        // Removed duplicates just for printing, but we need to figure out whats wrong with DB
        songs.Select(s=> s.TrackName).Distinct().ToList().ForEach(Console.WriteLine);
    }

    public static void ListSongsByAlbum()
    {
        using var context = new CompsciprojectContext();
        string albumName = "Californication";

        var songs = context.Songs
            .Where(s => s.AlbumName == albumName) // Filter songs by album name
            .ToList(); // Execute the query and get the results as a List

        //
        // Only getting 1 result? Doesn't seem right. Need to figure out whats wrong with DB
        //

        foreach (var song in songs)
        {
            Console.WriteLine(song.TrackName); // Print the name of the song
        }
    }
}