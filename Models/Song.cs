using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoundScape.Models;

public partial class Song
{
    [Key]
    public string TrackId { get; set; } = null!;
    [Required] // Not sure if we want this here
    public string? AlbumId { get; set; }

    public string? TrackName { get; set; }

    public int? Duration { get; set; }

    public string? Genre { get; set; }

    public string? Sample { get; set; }

    public virtual Album? Album { get; set; }

    public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; } = new List<PlaylistSong>();
}
