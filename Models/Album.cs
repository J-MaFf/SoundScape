using System;
using System.Collections.Generic;

namespace SoundScape.Models;

public partial class Album
{
    public string? Name { get; set; }

    public string AlbumId { get; set; } = null!;

    public long? Totalsongs { get; set; }

    public long? Duration { get; set; }

    public virtual ICollection<Song> Songs { get; set; } = new List<Song>();
}
