using System;
using System.Collections.Generic;

namespace COMPSCI366.Models;

public partial class Song
{
    public string TrackId { get; set; } = null!;

    public string? Artists { get; set; }

    public string? Albumname { get; set; }

    public int? Duration { get; set; }

    public string? Trackname { get; set; }

    public double? Danceability { get; set; }

    public string? Genre { get; set; }

    public bool? Profanity { get; set; }

    public string? AlbumId { get; set; }

    public virtual Album? Album { get; set; }
}
