using System;
using System.Collections.Generic;

namespace SoundScape.Models;

public partial class PlaylistSong
{
    public long PlaylistSongId { get; set; }

    public string? PlaylistId { get; set; }

    public string? TrackId { get; set; }

    public int? Order { get; set; }

    public virtual Playlist? Playlist { get; set; }
}
