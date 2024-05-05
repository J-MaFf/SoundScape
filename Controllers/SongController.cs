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

    public List<Song> SearchString(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            return _context.Songs.ToList();
        }
        var lowerKeyword = keyword.ToLower(); // Convert keyword to lowercase for case insensitive search
        return _context.Songs.Where(s => (s.Trackname != null && s.Trackname.ToLower().Contains(lowerKeyword)) ||
                                (s.Artists != null && s.Artists.ToLower().Contains(lowerKeyword)) ||
                                (s.Album != null && s.Album.Name.ToLower().Contains(lowerKeyword))).ToList();
    }
    public List<Song> SortByDuration(List<Song> songs)
    {
        return songs.OrderByDescending(song => song.Duration).ToList();
    }
    public List<Song> SortByDanceability(List<Song> songs)
    {
        return songs.OrderByDescending(song => song.Danceability).ToList();
    }
    public List<Song> FilterByProfanity(List<Song> songs)
    {
        return songs.Where(song => song.Profanity == false).ToList();
    }
    public List<Song> FilterByGenre(List<Song> songs, string genre)
    {
        return songs.Where(song => song.Genre.ToLower() == genre.ToLower()).ToList();
    }
}