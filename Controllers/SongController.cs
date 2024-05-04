using COMPSCI366.Models;

/// <summary>
/// Represents a controller for managing songs.
/// </summary>
public class SongController
{
    private readonly CompsciprojectContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="SongController"/> class.
    /// </summary>
    public SongController()
    {
        _context = new CompsciprojectContext();
    }

    /// <summary>
    /// Gets a list of songs by the specified artist.
    /// </summary>
    /// <param name="artist">The artist name.</param>
    /// <returns>A list of songs by the specified artist.</returns>
    public List<Song> GetSongsByArtist(string artist)
    {
        Console.WriteLine($"Searching for songs by {artist}:\n");
        var songs = _context.Songs
            .Where(s => s.Artists == artist)
            .ToList();

        songs.ForEach(s => Console.WriteLine(s.Trackname));

        Console.WriteLine($"There were {songs.Count} songs found by {artist}\n");

        return songs;
    }

    /// <summary>
    /// Gets a list of songs in the specified album.
    /// </summary>
    /// <param name="album">The album name.</param>
    /// <returns>A list of songs in the specified album.
    /// If the list is empty, the album was not found or it was empty.</returns>
    public List<Song> GetSongsByAlbum(string album)
    {
        Console.WriteLine($"Searching for songs in album {album}:\n");
        var songs = _context.Songs
            .Where(s => s.Albumname == album)
            .ToList();

        songs.ForEach(s => Console.WriteLine(s.Trackname));
        Console.WriteLine($"There are {songs.Count} songs in {album}\n");

        return songs;
    }

    /// <summary>
    /// Gets a list of songs with the specified name.
    /// </summary>
    /// <param name="name">The song name.</param>
    /// <returns>A list of songs with the specified name.
    /// If the list is empty, the song was not found.</returns>
    public List<Song> GetSongsByName(string name)
    {
        Console.WriteLine($"Searching for Songs named {name}\n");
        var songs = _context.Songs
            .Where(s => s.Trackname == name)
            .ToList();

        songs.ForEach(s => Console.WriteLine(s.Trackname));
        Console.WriteLine($"There are {songs.Count} songs named {name}\n");

        return songs;
    }

    /// <summary>
    /// Gets a list of songs with the specified danceability rating.
    /// </summary>
    /// <param name="danceability">The danceability rating.</param>
    /// <returns>A list of songs with the specified danceability rating.
    /// If the list is empty, no songs were found with the specified danceability rating.</returns>
    public List<Song> GetSongsByDanceability(double danceability)
    {
        Console.WriteLine($"Searching for songs with danceability rating of {danceability}\n");
        var songs = _context.Songs
            .Where(s => s.Danceability == danceability)
            .ToList();

        songs.ForEach(s => Console.WriteLine(s.Trackname));

        Console.WriteLine($"There are {songs.Count} songs with danceability rating of {danceability}\n");
        return songs;
    }
}