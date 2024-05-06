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
public class SongComparer : IEqualityComparer<Song>
{
    public bool Equals(Song? x, Song? y)
    {
        // Check whether the compared objects reference the same data.
        if (Object.ReferenceEquals(x, y)) return true;

        // Check whether any of the compared objects is null.
        if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
            return false;

        // Check whether the other properties are equal.
        return x.Trackname == y.Trackname && x.Artists == y.Artists && x.Albumname == y.Albumname;
    }

    public int GetHashCode(Song obj)
    {
        if (Object.ReferenceEquals(obj, null)) return 0;

        // Use hash code of string properties and combine them
        int hashTrackName = obj.Trackname == null ? 0 : obj.Trackname.GetHashCode();
        int hashArtists = obj.Artists == null ? 0 : obj.Artists.GetHashCode();
        int hashAlbumName = obj.Albumname == null ? 0 : obj.Albumname.GetHashCode();

        // Combine the hash codes using an approach like XOR to blend their values
        return hashTrackName ^ hashArtists ^ hashAlbumName;
    }
}