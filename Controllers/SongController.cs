using COMPSCI366.Models;

public class SongController
{
    private readonly CompsciprojectContext _context;

    public SongController()
    {
        _context = new CompsciprojectContext();
    }

    public List<Song> ListSongsByArtist(string artist)
    {
        Console.WriteLine($"Searching for songs by {artist}:\n");
        var songs = _context.Songs
            .Where(s => s.Artists == artist)
            .ToList();

        songs.ForEach(s => Console.WriteLine(s.Trackname));

        Console.WriteLine($"There were {songs.Count} songs found by {artist}\n");

        return songs;
    }

    public List<Song> ListSongsByAlbum(string album)
    {
        Console.WriteLine($"Searching for songs in album {album}:\n");
        var songs = _context.Songs
            .Where(s => s.Albumname == album)
            .ToList();

        songs.ForEach(s => Console.WriteLine(s.Trackname));
        Console.WriteLine($"There are {songs.Count} songs in {album}\n");

        return songs;
    }

    public List<Song> ListSongsByName(string name)
    {
        Console.WriteLine($"Searching for Songs named {name}\n");
        var songs = _context.Songs
            .Where(s => s.Trackname == name)
            .ToList();

        songs.ForEach(s => Console.WriteLine(s.Trackname));
        Console.WriteLine($"There are {songs.Count} songs named {name}\n");

        return songs;
    }

    public List<Song> ListSongsByDanceability(double danceability)
    {
        Console.WriteLine($"Searching for songs with danceability rating of {danceability}\n");
        var songs = _context.Songs
            .Where(s => s.Danceability == danceability)
            .ToList();

        songs.ForEach(s => Console.WriteLine());

        Console.WriteLine($"There are {songs.count} songs with danceability rating of {danceability}\n");
        return songs;
    }

}