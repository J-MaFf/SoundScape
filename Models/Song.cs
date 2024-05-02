using System;
using System.Collections.Generic;

namespace SoundScape.Models;

public partial class Song
{
    public string TrackID { get; set; } = null!;

    public string? Artists { get; set; }

    public string? AlbumName { get; set; }

    public int? Duration { get; set; }

    public string? TrackName { get; set; }

    public double? Danceability { get; set; }

    public string? Genre { get; set; }

    public bool? Profanity { get; set; }

    public string? AlbumID { get; set; }

    public string? AlbumAlbumID { get; set; }

    public virtual Album? Album { get; set; }
}
