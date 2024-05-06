using COMPSCI366.Models;
using Microsoft.VisualBasic.Devices;
using System.Security.Cryptography;

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

        _context.Users.Remove(userToDelete);
        _context.SaveChanges();

        return true;
    }
}