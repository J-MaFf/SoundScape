using System;
using System.Collections.Generic;

namespace SoundScape.Models;

public partial class Album
{
    public string? Albumname { get; set; }

    public long? Numberofsongs { get; set; }

    public long? Duration { get; set; }

    public string AlbumId { get; set; } = null!;

    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}
