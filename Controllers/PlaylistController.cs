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

    /// <summary>
    /// Retrieves a list of playlists owned by the specified user.
    /// </summary>
    /// <param name="username">The username of the user.</param>
    /// <returns>A list of playlists owned by the user.
    /// If return value is an empty list, then no playlists owned by the user were found.</returns>
    public List<Playlist> GetPlaylistsByUser(string username)
    {
        Console.WriteLine($"Searching for playlists by {username}:\n");
        var playlists = _context.Playlists
            .Where(p => p.Username == username)
            .ToList();

        playlists.ForEach(p => Console.WriteLine(p.PlaylistName));
        Console.WriteLine($"There are {playlists.Count} playlists by {username}\n");

        return playlists;
    }

    /// <summary>
    /// Retrieves a list of playlists with the specified name.
    /// </summary>
    /// <param name="playlistName">The name of the playlist.</param>
    /// <returns>A list of playlists with the specified name. If return value
    /// is an empty list, then no playlists with the specified name were found.</returns>
    public List<Playlist> GetPlaylistsByName(string playlistName)
    {
        Console.WriteLine($"Searching for playlists named {playlistName}:\n");
        var playlists = _context.Playlists
            .Where(p => p.PlaylistName == playlistName)
            .ToList();

        playlists.ForEach(p => Console.WriteLine(p.PlaylistName));
        Console.WriteLine($"There are {playlists.Count} playlists named {playlistName}\n");

        return playlists;
    }
    /// <summary>
    /// Retrieves a playlist with the specified name and user.
    /// </summary>
    /// <param name="playlistName"></param>
    /// <param name="username"></param>
    /// <returns>The playlist with the specified name and user. If return value is null,
    /// then no playlist with the specified name and user was found.</returns>
    public Playlist? GetPlaylistByNameAndUser(string playlistName, string username)
    {
        Console.WriteLine($"Searching for playlist named {playlistName} by user {username}:\n");
        var playlist = _context.Playlists
            .Where(p => p.PlaylistName == playlistName && p.Username == username)
            .FirstOrDefault();

        if (playlist == null)
        {
            Console.WriteLine($"Playlist named {playlistName} by user {username} not found\n");
            return null;
        }

        Console.WriteLine($"Playlist named {playlistName} by user {username} found\n");
        return playlist;
    }

    /// <summary>
    /// Retrieves a list of songs in the specified playlist.
    /// </summary>
    /// <param name="playlistId"></param>
    /// <returns>A list of songs in the playlist. If return value is an empty list,
    /// then no songs were found in the playlist.</returns>
    public List<PlaylistSong> GetPlaylistSongs(string playlistId)
    {
        Console.WriteLine($"Listing songs in playlist {playlistId}:\n");
        var playlistSongs = _context.PlaylistSongs
            .Where(ps => ps.PlaylistId == playlistId)
            .ToList();

        playlistSongs.ForEach(ps => Console.WriteLine(ps.TrackId));
        Console.WriteLine($"There are {playlistSongs.Count} songs in playlist {playlistId}\n");

        return playlistSongs;
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
        Console.WriteLine($"Deleting playlist {playlistId}:\n");
        var playlist = _context.Playlists
            .Where(p => p.PlaylistId == playlistId)
            .FirstOrDefault();

        if (playlist == null)
        {
            Console.WriteLine($"Playlist {playlistId} not found\n");
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
            Console.WriteLine($"Failed to remove all songs from playlist {playlistId}\n");
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

        Console.WriteLine($"Song named {track.Trackname} with TrackId {trackId} added to playlist {playlistId}\n");

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
        Console.WriteLine($"Removing song {trackId} from playlist {playlistId}:\n");

        var playlistSong = _context.PlaylistSongs
            .Where(ps => ps.PlaylistId == playlistId && ps.TrackId == trackId)
            .FirstOrDefault();

        if (playlistSong == null)
        {
            Console.WriteLine($"Song {trackId} not found in playlist {playlistId}\n");
            return false;
        }



        _context.PlaylistSongs.Remove(playlistSong);

        // Change the order of the songs after the removed song
        var playlistSongs = _context.PlaylistSongs
            .Where(ps => ps.PlaylistId == playlistId && ps.Order > playlistSong.Order)
            .ToList();

        playlistSongs.ForEach(ps => ps.Order--);

        _context.SaveChanges();

        Console.WriteLine($"Song {trackId} removed from playlist {playlistId}\n");

        return true;
    }
}