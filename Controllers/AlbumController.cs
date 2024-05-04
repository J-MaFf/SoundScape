using COMPSCI366.Models;

public class AlbumController
{
    private readonly CompsciprojectContext _context;

    public AlbumController()
    {
        _context = new CompsciprojectContext();
    }

    public List<Album> ListAlbumsByName(string name)
    {
        Console.WriteLine($"Searching for albums named {name}");
        var albums = _context.Albums
            .Where(a => a.Name == name)
            .ToList();

        albums.ForEach(a => Console.WriteLine(a.Name));

        Console.WriteLine($"There were {albums.Count} album(s) found named {name}");

        return albums;
    }

    // List albums by artist
    public List<Album> ListAlbumsByArtist(string artist)
    {
        Console.WriteLine($"Searching for albums by artist {artist}");
        var albums = _context.Albums
            .Where(a => a.Artist == artist)
            .ToList();

        albums.ForEach(a => Console.WriteLine(a.Name));

        Console.WriteLine($"There were {albums.Count} album(s) found by artist {artist}");

        return albums;
    }
}