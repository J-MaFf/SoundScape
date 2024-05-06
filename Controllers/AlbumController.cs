using COMPSCI366.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.Devices;

public class AlbumController : Controller
{

    public AlbumController()
    {
    }

    public List<Album> SearchString(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            return _albums;
        }
        var lowerKeyword = keyword.ToLower();
        return _context.Albums.AsNoTracking()
        .Where(album =>
            (album.Name != null && album.Name.ToLower().Contains(lowerKeyword)) ||  // Search in album names
            _context.Songs.AsNoTracking().Any(song =>
                song.AlbumId == album.AlbumId &&  // Ensure the song belongs to the current album
                (song.Trackname != null && song.Trackname.ToLower().Contains(lowerKeyword) ||
                 song.Artists != null && song.Artists.ToLower().Contains(lowerKeyword) ||
                 song.Albumname != null && song.Albumname.ToLower().Contains(lowerKeyword)))
        )
        .ToList();

    }
    public static List<Album> SortByDuration(List<Album> albums)
    {
        return [.. albums.OrderByDescending(album => album.Duration)];
    }
    public static List<Album> SortByTotalSongs(List<Album> albums)
    {
        return [.. albums.OrderByDescending(album => album.Totalsongs)];
    }
}