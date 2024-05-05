using COMPSCI366.Models;
using Microsoft.VisualBasic.Devices;

/// <summary>
/// Represents a controller for managing user-related operations.
/// </summary>
public class UserController
{
    private readonly CompsciprojectContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserController"/> class.
    /// </summary>
    public UserController()
    {
        _context = new CompsciprojectContext();
    }
    public List<User> SearchString(string keyword)
    {
        if(string.IsNullOrWhiteSpace(keyword))
        {
            return _context.Users.ToList();
        }
        var lowerKeyword = keyword.ToLower(); // Convert keyword to lowercase for case insensitive search
        return _context.Users.Where(user =>
            user.Username != null && user.Username.ToLower().Contains(lowerKeyword) ||
            user.Playlists != null && user.Playlists.Any(playlist =>
                playlist.PlaylistName != null && playlist.PlaylistName.ToLower().Contains(lowerKeyword))
        ).ToList();
    }

    public List<User> SortByMinutes(List<User> users)
    {
        return users.OrderByDescending(user => user.MinutesListened).ToList();
    }

    /// <summary>
    /// Retrieves a user by their username.
    /// </summary>
    /// <param name="username">The username of the user to retrieve.</param>
    /// <returns>The user with the specified username, or null if not found.</returns>
    public User? GetUser(string username)
    {
        Console.WriteLine($"Searching for user {username}\n");

        var user = _context.Users
            .FirstOrDefault(x => x.Username == username);

        if (user == null)
        {
            Console.WriteLine($"{username} is not a user\n");
            return null;
        }
        Console.WriteLine($"{username} found.\n");
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
        Console.WriteLine($"Creating new user {username}\n");

        // Check to see if username already exists in the database
        if (_context.Users.Any(x => x.Username == username))
        {
            Console.WriteLine($"{username} is already a user\n");
            return null;
        }

        User newUser = new();
        newUser.Username = username;
        newUser.Password = password;
        newUser.MinutesListened = 0;

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
        Console.WriteLine($"Attempting to delete {username}\n");

        var userToDelete = _context.Users
            .FirstOrDefault(x => x.Username == username);

        if (userToDelete == null)
        {
            Console.WriteLine($"Cannot delete {username} because that user does not exist\n");
            return false;
        }

        _context.Users.Remove(userToDelete);
        _context.SaveChanges();

        Console.WriteLine($"User {username} deleted");
        return true;
    }
}