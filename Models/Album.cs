using System;
using System.Collections.Generic;

namespace SoundScape.Models;

public partial class Album
{
    public string? Name { get; set; }

    public string AlbumID { get; set; } = null!;

    public long? TotalSongs { get; set; }

    public long? Duration { get; set; }

    public virtual ICollection<Song> Songs { get; set; } = [];
}
