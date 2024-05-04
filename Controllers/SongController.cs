using COMPSCI366.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class SongController
{
    private readonly CompsciprojectContext _context;

    public SongController()
    {
        _context = new CompsciprojectContext();
    }

    public List<Song> ListSongsByArtist(string artist)
    {
        var songs = _context.Songs
            .Where(s => s.Artists == artist)
            .ToList();

        songs.ForEach(s => Console.WriteLine(s.Trackname));

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

    public Song UpdateSong(string oldSongName, string newSongName)
    {
        var song = _context.Songs.FirstOrDefault(s => s.Trackname == oldSongName);

        if (song != null)
        {
            song.Trackname = newSongName;
            _context.SaveChanges();
        }
        else
        {
            Console.WriteLine("Song not found.");
        }

        return song;
    }
}