using COMPSCI366.Models;
namespace SoundScape.Controllers;
#pragma warning disable CS8602 // Dereference of a possibly null reference.


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
        return [.. _context.Songs.Where(s => (s.Trackname != null && s.Trackname.Contains(lowerKeyword, StringComparison.CurrentCultureIgnoreCase)) ||
                                (s.Artists != null && s.Artists.Contains(lowerKeyword, StringComparison.CurrentCultureIgnoreCase)) ||
                                (s.Album != null && s.Album.Name != null && s.Album.Name.Contains(lowerKeyword, StringComparison.CurrentCultureIgnoreCase)))];
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
        return songs.Where(song => song.Genre.Equals(genre, StringComparison.CurrentCultureIgnoreCase)).ToList();
    }
}