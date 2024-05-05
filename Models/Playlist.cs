using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace COMPSCI366.Models;

public partial class Playlist
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string PlaylistId { get; set; } = null!;

    public string? Username { get; set; }

    public string? PlaylistName { get; set; }

    public string? Description { get; set; }

    public DateTime? CreationDate { get; set; }

    public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; } = new List<PlaylistSong>();

    public virtual User? UsernameNavigation { get; set; }
}
