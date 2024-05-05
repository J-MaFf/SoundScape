using COMPSCI366.Models;

public class PlaylistController
{
    private readonly CompsciprojectContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="PlaylistController"/> class.
    /// </summary>
    public PlaylistController()
    {
        _context = new CompsciprojectContext();
    }

    public List<Playlist> SearchString(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            return _context.Playlists.ToList();
        }
        var lowerKeyword = keyword.ToLower(); // Case insensitive search
        SongController songController = new SongController();
        return _context.Playlists.Where(playlist =>
            playlist.PlaylistName != null && playlist.PlaylistName.ToLower().Contains(lowerKeyword) ||
            playlist.Username != null && playlist.Username.ToLower().Contains(lowerKeyword) ||
            playlist.PlaylistSongs != null && songController.GetSongsByID(playlist.PlaylistSongs.ToList()).Any(song =>
                song.Trackname != null && song.Trackname.ToLower().Contains(lowerKeyword) ||
                song.Artists != null && song.Artists.ToLower().Contains(lowerKeyword) ||
                song.Albumname != null && song.Albumname.ToLower().Contains(lowerKeyword)
            )
        ).ToList();
    }
    public List<Playlist> SortByCreationDate(List<Playlist> playlists)
    {
        return _context.Playlists.OrderByDescending(playlist => playlist.CreationDate).ToList();
    }

    /// <summary>
    /// Creates a new playlist for the specified user.
    /// </summary>
    /// <param name="username">The username of the user.</param>
    /// <param name="playlistName">The name of the playlist.</param>
    /// <param name="description">The description of the playlist.</param>
    /// <returns>The created playlist. If return value is null, the method failed.</returns>
    public Playlist? CreatePlaylist(string username, string playlistName, string description)
    {
        Console.WriteLine($"Creating playlist {playlistName} for user {username}:\n");

        // Check if the user exists
        var user = _context.Users.Find(username);
        if (user == null)
        {
            Console.WriteLine($"User {username} not found\n");
            return null;
        }

        // Check if the playlist already exists
        if (_context.Playlists.Any(p => p.Username == username && p.PlaylistName == playlistName))
        {
            Console.WriteLine($"Playlist {playlistName} already exists for user {username}\n");
            return null;
        }

        var playlist = new Playlist
        {
            Username = username,
            PlaylistName = playlistName,
            Description = description,
            CreationDate = DateTime.Now
        };

        _context.Playlists.Add(playlist);
        _context.SaveChanges();

        Console.WriteLine($"Playlist {playlistName} created for user {username}\n");

        return playlist;
    }

    /// <summary>
    /// Deletes a playlist with the specified playlistId.
    /// </summary>
    /// <param name="playlistId">The ID of the playlist to delete.</param>
    /// <returns>True if the playlist was successfully deleted, false otherwise.</returns>
    public bool DeletePlaylist(string playlistId)
    {
        var playlist = _context.Playlists.Find(playlistId);

        if (playlist == null)
        {
            Console.WriteLine($"Playlist {playlistId} not found\n");
            return false;
        }
        Console.WriteLine($"Deleting playlist {playlist.PlaylistName}:\n");

        // Remove all songs from the playlist
        var playlistSongs = _context.PlaylistSongs
            .Where(ps => ps.PlaylistId == playlistId)
            .ToList();

        playlistSongs.ForEach(ps => _context.PlaylistSongs.Remove(ps));

        _context.SaveChanges();

        // Verify that all songs were removed
        if (_context.PlaylistSongs.Any(ps => ps.PlaylistId == playlistId))
        {
            Console.WriteLine($"Failed to remove all songs from playlist {playlist.PlaylistName} with ID {playlistId}\n");
            return false;
        }

        _context.Playlists.Remove(playlist);
        _context.SaveChanges();

        Console.WriteLine($"Playlist named {playlist.PlaylistName} with Id {playlistId} deleted\n");
        return true;
    }

    /// <summary>
    /// Adds a song to the specified playlist.
    /// </summary>
    /// <param name="playlistId">The ID of the playlist.</param>
    /// <param name="trackId">The ID of the song to add.</param>
    /// <returns>The added playlist song. If return value is null, the method failed.</returns>
    public PlaylistSong? AddSongToPlaylist(string playlistId, string trackId)
    {
        // Check if the playlist exists
        var playlist = _context.Playlists.Find(playlistId);
        if (playlist == null)
        {
            Console.WriteLine($"Playlist {playlistId} not found\n");
            return null;
        }

        // Check if the track exists
        var track = _context.Songs.Find(trackId);
        if (track == null)
        {
            Console.WriteLine($"Track {trackId} not found\n");
            return null;
        }

        Console.WriteLine($"Adding song named {track.Trackname} with TrackId {trackId} to playlist named {playlist.PlaylistName} with PlaylistId {playlistId}:\n");

        // Calculate the order for the new song
        int order = 1;
        if (_context.PlaylistSongs.Any(ps => ps.PlaylistId == playlistId))
        {
            order = _context.PlaylistSongs
                .Where(ps => ps.PlaylistId == playlistId)
                .Max(ps => ps.Order) + 1;
        }

        var playlistSong = new PlaylistSong
        {
            PlaylistId = playlistId,
            TrackId = trackId,
            Order = order
        };

        _context.PlaylistSongs.Add(playlistSong);
        _context.SaveChanges();

        Console.WriteLine($"Song named {track.Trackname} added to playlist named {playlist.PlaylistName}\n");

        return playlistSong;
    }

    /// <summary>
    /// Removes a song from the specified playlist.
    /// </summary>
    /// <param name="playlistId">The ID of the playlist.</param>
    /// <param name="trackId">The ID of the song to remove.</param>
    /// <returns>True if the song was successfully removed, false otherwise.</returns>
    public bool RemoveSongFromPlaylist(string playlistId, string trackId)
    {
        var playlist = _context.Playlists.Find(playlistId);
        var song = _context.Songs.Find(trackId);

        if (playlist == null || song == null)
        {
            Console.WriteLine($"Playlist with ID {playlistId} or song with ID {trackId} not found\n");
            return false;
        }

        Console.WriteLine($"Removing song {song.Trackname} from playlist {playlist.PlaylistName}:\n");

        var playlistSong = _context.PlaylistSongs
            .Where(ps => ps.PlaylistId == playlistId && ps.TrackId == trackId)
            .FirstOrDefault();

        if (playlistSong == null)
        {
            Console.WriteLine($"Song {trackId} not found in playlist {playlist.PlaylistName}\n");
            return false;
        }

        _context.PlaylistSongs.Remove(playlistSong);

        // Change the order of the songs after the removed song
        var playlistSongs = _context.PlaylistSongs
            .Where(ps => ps.PlaylistId == playlistId && ps.Order > playlistSong.Order)
            .ToList();

        playlistSongs.ForEach(ps => ps.Order--);
        _context.SaveChanges();
        Console.WriteLine($"Song {song.Trackname} removed from playlist {playlist.PlaylistName}\n");
        return true;
    }
}