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
            .Join(
                _context.Songs, // The table to join with
                album => album.AlbumId, // The key selector for the outer sequence
                song => song.AlbumId, // The key selector for the inner sequence
                (album, song) => new { Album = album, Song = song }
            )
            .Where(albumAndSong => albumAndSong.Song.Artists == artist)
            .Select(albumAndSong => albumAndSong.Album)
            .Distinct()
            .ToList();

        Console.WriteLine($"There were {albums.Count} album(s) found by artist {artist}");

        return albums;
    }
}