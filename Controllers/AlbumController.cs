using COMPSCI366.Models;
using Microsoft.VisualBasic.Devices;

public class AlbumController
{
    private readonly CompsciprojectContext _context;

    public AlbumController()
    {
        _context = new CompsciprojectContext();
    }

    public List<Album> SearchString(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            return _context.Albums.ToList();
        }
        var lowerKeyword = keyword.ToLower(); // Convert keyword to lowercase for case insensitive search
        return [.. _context.Albums.Where(album =>
            (album.Name != null && album.Name.ToLower().Contains(lowerKeyword)) ||
            (album.Songs != null && album.Songs.Any(song =>
                (song.Trackname != null && song.Trackname.ToLower().Contains(lowerKeyword)) ||
                (song.Artists != null && song.Artists.ToLower().Contains(lowerKeyword))
            ))
        )];
    }
    public static List<Album> SortByDuration(List<Album> albums)
    {
        return albums.OrderByDescending(album => album.Duration).ToList();
    }
    public static List<Album> SortByTotalSongs(List<Album> albums)
    {
        return albums.OrderByDescending(album => album.Totalsongs).ToList();
    }
}