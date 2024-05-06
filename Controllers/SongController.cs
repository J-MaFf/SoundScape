using COMPSCI366.Models;

/// <summary>
/// Represents a controller for managing songs.
/// </summary>
public class SongController : Controller
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SongController"/> class.
    /// </summary>
    public SongController()
    {
    }

    public List<Song> SearchString(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            return _songs.ToList();
        }
        var lowerKeyword = keyword.ToLower(); // Convert keyword to lowercase for case insensitive search
        var filteredSongs = _songs.Where(s => (s.Trackname != null && s.Trackname.ToLower().Contains(lowerKeyword)) ||
                                (s.Artists != null && s.Artists.ToLower().Contains(lowerKeyword)) ||
                                (s.Album != null && s.Album.Name.ToLower().Contains(lowerKeyword))).ToList();
        return filteredSongs.Distinct(new SongComparer()).ToList();
    }
    public List<Song> SortByDuration(List<Song> songs)
    {
        return songs.OrderByDescending(song => song.Duration).ToList();
    }
    public List<Song> SortByDanceability(List<Song> songs)
    {
        return songs.OrderByDescending(song => song.Danceability).ToList();
    }
    public List<Song> SortByGenre(List<Song> songs)
    {
        return songs.OrderBy(song => song.Genre).ToList();
    }
    public List<Song> FilterByProfanity(List<Song> songs)
    {
        return songs.Where(song => song.Profanity == false).ToList();
    }
}