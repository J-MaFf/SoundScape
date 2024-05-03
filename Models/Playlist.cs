using System;
using System.Collections.Generic;

namespace COMPSCI366.Models;

public partial class Playlist
{
    public Playlist(string playlistId, string? username, string? playlistName, string? description, DateTime? creationDate, ICollection<PlaylistSong> playlistSongs, User? usernameNavigation)
    {

        PlaylistId = playlistId;
        Username = username;
        PlaylistName = playlistName;
        Description = description;
        CreationDate = creationDate;
        PlaylistSongs = playlistSongs;
        UsernameNavigation = usernameNavigation;
    }

    public string PlaylistId { get; set; } = null!;

    public string? Username { get; set; }

    public string? PlaylistName { get; set; }

    public string? Description { get; set; }

    public DateTime? CreationDate { get; set; }

    public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; } = new List<PlaylistSong>();

    public virtual User? UsernameNavigation { get; set; }
}
