using SoundScape.Models;

public class QueryController
{
    public void ListSongsByArtist()
    {
        using (var context = new CompsciprojectContext())
        {
            string artistName = "Red Hot Chili Peppers";

            var songs = context.Songs
                .Where(s => s.Artists == artistName) // Filter songs by artist name
                .ToList(); // Execute the query and get the results as a List

            foreach (var song in songs)
            {
                Console.WriteLine(song.Trackname); // Print the name of the song
            }
        }
    }
}