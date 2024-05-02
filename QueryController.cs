using SoundScape.Models;

public class QueryController
{
    public static void ListSongsByArtist()
    {
        using CompSciProjectContext context = new();
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
        using var context = new CompSciProjectContext();
        string albumName = "Californication";

        var songs = context.Songs
            .Where(s => s.AlbumName == albumName) // Filter songs by album name
            .ToList(); // Execute the query and get the results as a List

        //
        // Only getting 1 result? Doesn't seem right. Need to figure out whats wrong with DB
        //

        songs.ForEach(s => Console.WriteLine(s.TrackName));
    }

    public static void ListAlbumsBySong(string songName)
    {
        using var context = new CompSciProjectContext();

        var albums = context.Albums
        .Where(a => a.Songs.Where(s => s.TrackName == songName).Any()).ToList();

        foreach (var album in albums)
        {
            var artists = album.Songs
                .Select(s => s.TrackName)  // Select artists from songs
                .Distinct()             // Remove duplicates
                .ToList();              // Convert to list
        
            // Print album name and artists
            Console.WriteLine($"Album: {album.Name} by {string.Join(", ", artists)}");
        }

    }
}