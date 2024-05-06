using COMPSCI366.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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

        var playlistSongs = _context.PlaylistSongs.ToList();
        var songIds = playlistSongs.Select(ps => ps.TrackId).ToList(); // Extract song IDs from playlist entries
        var songs = _context.Songs.Where(song => songIds.Contains(song.TrackId)); // Get songs by ID

        return _context.Playlists.Where(playlist =>
            playlist.PlaylistName != null && playlist.PlaylistName.ToLower().Contains(lowerKeyword) ||
            playlist.Description != null && playlist.Description.ToLower().Contains(lowerKeyword) ||
            playlist.Username != null && playlist.Username.ToLower().Contains(lowerKeyword) ||
            songs.Any(song => song.Trackname != null && song.Trackname.ToLower().Contains(lowerKeyword))
        ).ToList();
    }
    public List<Playlist> SortByCreationDate(List<Playlist> playlists)
    {
        return _context.Playlists.OrderByDescending(playlist => playlist.CreationDate).ToList();
    }
    public List<Song> GetSongsByID(List<PlaylistSong> playlistSongs)
    {
        var songIds = playlistSongs.Select(ps => ps.TrackId).ToList(); // Extract song IDs from playlist entries
        return _context.Songs.Where(song => songIds.Contains(song.TrackId)).ToList();
    }

    public Playlist? GetPlaylist(string username, string playlistName)
    {
        return _context.Playlists.FirstOrDefault(playlist => playlist.Username == username && playlist.PlaylistName == playlistName);
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
        // Check if the user exists
        var user = _context.Users.Find(username);
        if (user == null)
        {
            return null;
        }

        // Check if the playlist already exists
        if (_context.Playlists.Any(p => p.Username == username && p.PlaylistName == playlistName))
        {
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
            return false;
        }

        // Remove all songs from the playlist
        var playlistSongs = _context.PlaylistSongs
            .Where(ps => ps.PlaylistId == playlistId)
            .ToList();

        playlistSongs.ForEach(ps => _context.PlaylistSongs.Remove(ps));

        _context.SaveChanges();

        // Verify that all songs were removed
        if (_context.PlaylistSongs.Any(ps => ps.PlaylistId == playlistId))
        {
            return false;
        }

        _context.Playlists.Remove(playlist);
        _context.SaveChanges();

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
            return null;
        }

        // Check if the track exists
        var track = _context.Songs.Find(trackId);
        if (track == null)
        {
            return null;
        }


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
            return false;
        }

        var playlistSong = _context.PlaylistSongs
            .Where(ps => ps.PlaylistId == playlistId && ps.TrackId == trackId)
            .FirstOrDefault();

        if (playlistSong == null)
        {;
            return false;
        }

        _context.PlaylistSongs.Remove(playlistSong);

        // Change the order of the songs after the removed song
        var playlistSongs = _context.PlaylistSongs
            .Where(ps => ps.PlaylistId == playlistId && ps.Order > playlistSong.Order)
            .ToList();

        playlistSongs.ForEach(ps => ps.Order--);
        _context.SaveChanges();
        return true;
    }

    public bool EraseAllPlaylistsAndPlaylistSongs()
    {
        Console.WriteLine("Erasing all playlists and playlist songs:\n");

        _context.Playlists.RemoveRange(_context.Playlists);
        _context.PlaylistSongs.RemoveRange(_context.PlaylistSongs);
        _context.SaveChanges();

        Console.WriteLine("All playlists and playlist songs erased\n");
        return true;
    }
}