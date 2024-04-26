using System.ComponentModel.DataAnnotations;
namespace Models;
public class Song
{
    [Key]
    public int TrackID { get; set; }
    [Required]
    public int AlbumID { get; set; }
    [Required]
    public string TrackName { get; set; }
    [Required]
    public TimeSpan Duration { get; set; }
    public string Genre { get; set; }

    public byte[] Sample { get; set; }

    // Artist is probably needed here, but is not currently included in this table
}