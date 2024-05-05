using COMPSCI366.Models;
namespace SoundScape.Controllers;

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

    public List<Song> SearchString(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            return [.. _context.Songs]; // Return all songs as List if keyword is empty
        }
        var lowerKeyword = keyword.ToLower(); // Convert keyword to lowercase for case insensitive search
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        return [.. _context.Songs.Where(s => (s.Trackname != null && s.Trackname.ToLower().Contains(lowerKeyword)) ||
                                (s.Artists != null && s.Artists.ToLower().Contains(lowerKeyword)) ||
                                (s.Album != null && s.Album.Name.ToLower().Contains(lowerKeyword)))];
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
    public static List<Song> SortByDuration(List<Song> songs)
    {
        
        return songs.OrderByDescending(song => song.Duration).ToList();
    }
    public static List<Song> SortByDanceability(List<Song> songs)
    {
        return songs.OrderByDescending(song => song.Danceability).ToList();
    }
    public static List<Song> FilterByProfanity(List<Song> songs)
    {
        return songs.Where(song => song.Profanity == false).ToList();
    }
    public static List<Song> FilterByGenre(List<Song> songs, string genre)
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        return songs.Where(song => song.Genre.Equals(genre, StringComparison.CurrentCultureIgnoreCase)).ToList();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
}