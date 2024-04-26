public class Song
{
    public int TrackID { get; set; }
    public int AlbumID { get; set; }
    public string TrackName { get; set; }
    public TimeSpan Duration { get; set; }
    public string Genre { get; set; }
    public byte[] Sample { get; set; }

    // Artist is probably needed here, but is not currently included in this table
}