using COMPSCI366.Models;
using Microsoft.EntityFrameworkCore;
public class Controller
{
    protected static readonly CompsciprojectContext _context = new();
    public static readonly List<Song> _songs = _context.Songs.ToList();
    public static readonly List<Album> _albums = _context.Albums.ToList();
    public Controller()
	{

    }
}
