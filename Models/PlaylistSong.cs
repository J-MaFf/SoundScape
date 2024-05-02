using System;
using System.Collections.Generic;

namespace SoundScape.Models;

public partial class PlaylistSong
{
    public long PlaylistSongID { get; set; }

    public string? PlaylistID { get; set; }

    public string? TrackID { get; set; }

    public int? Order { get; set; }

    public virtual Playlist? Playlist { get; set; }
}
