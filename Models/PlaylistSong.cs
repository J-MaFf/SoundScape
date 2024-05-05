using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMPSCI366.Models;

public partial class PlaylistSong
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string PlaylistSongId { get; set; } = null!;

    public string? PlaylistId { get; set; }

    public string? TrackId { get; set; }

    public int Order { get; set; }

    public virtual Playlist? Playlist { get; set; }
}
