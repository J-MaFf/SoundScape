using System;
using System.Collections.Generic;

namespace SoundScape.Models;

public partial class User
{
    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public long? MinutesListened { get; set; }

    public virtual ICollection<Playlist> Playlists { get; set; } = [];
}
