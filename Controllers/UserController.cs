using COMPSCI366.Models;

/// <summary>
/// Represents a controller for managing user-related operations.
/// </summary>
public class UserController : Controller
{

    /// <summary>
    /// Initializes a new instance of the <see cref="UserController"/> class.
    /// </summary>
    public UserController()
    {
    }
    public List<User> SearchString(string keyword)
    {
        var lowerKeyword = keyword.ToLower(); // Case insensitive search
        var users = _context.Users.ToList();
        var playlists = _context.Playlists.ToList();
        var ids = playlists.Select(pl => pl.PlaylistId).ToList();
        if (string.IsNullOrWhiteSpace(keyword))
        {
            return [.. _context.Users]; // Used collection expression (for compiler warning)
        }
        return _context.Users.Where(user =>
            user.Username != null && user.Username.ToLower().Contains(lowerKeyword) ||
            user.Playlists != null && user.Playlists.Any(playlist =>
                playlist.PlaylistName != null && playlist.PlaylistName.Contains(lowerKeyword, StringComparison.CurrentCultureIgnoreCase))
        )];
    }

    public static List<User> SortByMinutes(List<User> users)
    {
        return [.. users.OrderByDescending(user => user.MinutesListened)];
    }

    /// <summary>
    /// Retrieves a user by their username.
    /// </summary>
    /// <param name="username">The username of the user to retrieve.</param>
    /// <returns>The user with the specified username, or null if not found.</returns>
    public User? GetUser(string username)
    {

        var user = _context.Users
            .FirstOrDefault(x => x.Username == username);

        if (user == null)
        {
            return null;
        }
        return user;
    }

    /// <summary>
    /// Creates a new user with the specified username and password.
    /// </summary>
    /// <param name="username">The username of the new user.</param>
    /// <param name="password">The password of the new user.</param>
    /// <returns>The newly created user, or null if the username already exists.</returns>
    public User? CreateNewUser(string username, string password)
    {
        // Check to see if username already exists in the database
        if (_context.Users.Any(x => x.Username == username))
        {
            return null;
        }

        User newUser = new();
        newUser.Username = username;
        newUser.Password = password;
        Random rnd = new Random();
        int num = rnd.Next(0,15000);
        newUser.MinutesListened = num;

        // Add user to database
        _context.Users.Add(newUser);
        // Save changes
        _context.SaveChanges();

        return newUser;
    }

    /// <summary>
    /// Deletes a user with the specified username.
    /// </summary>
    /// <param name="username">The username of the user to delete.</param>
    /// <returns>True if the user was successfully deleted, false otherwise.</returns>
    public bool DeleteUser(string username)
    {
        var userToDelete = _context.Users
            .FirstOrDefault(x => x.Username == username);

        if (userToDelete == null)
        {
            return false;
        }

        var playlists = _context.Playlists.Where(p => p.Username == username).ToList();

        PlaylistController pC = new();
        foreach (var playlist in playlists)
        {
            pC.DeletePlaylist(playlist.PlaylistId);
        }
        _context.Users.Remove(userToDelete);
        _context.SaveChanges();

        return true;
    }
}