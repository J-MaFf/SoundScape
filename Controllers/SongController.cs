using COMPSCI366.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.VisualStyles;

public class SongController
{
    private readonly CompsciprojectContext _context;

    public SongController()
    {
        _context = new CompsciprojectContext();
    }

    public List<Song> ListSongsByArtist(string artist)
    {
        Console.WriteLine($"Searching for songs by {artist}");
        var songs = _context.Songs
            .Where(s => s.Artists == artist)
            .ToList();

        songs.ForEach(s => Console.WriteLine(s.Trackname));

        Console.WriteLine($"There were {songs.ToList().Count} songs found by {artist}");

        return songs;
    }

    public List<Song> ListSongsByAlbum(string album)
    {
        var songs = _context.Songs
            .Where(s => s.Albumname == album)
            .ToList();

        songs.ForEach(s => Console.WriteLine(s.Trackname));

        return songs;
    }

    public List<Song> ListSongsByName(string name)
    {
        var songs = _context.Songs
            .Where(s => s.Trackname == name)
            .ToList();

        songs.ForEach(s => Console.WriteLine(s.Trackname));

        return songs;
    }

    public List<Song> ListSongsByDanceability(double danceability)
    {
        var songs = _context.Songs
            .Where(s => s.Danceability == danceability)
            .ToList();

        songs.ForEach(s => Console.WriteLine());

        return songs;
    }

}