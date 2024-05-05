using COMPSCI366.Models;

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

    /// <summary>
    /// Retrieves all users from the database.
    /// </summary>
    /// <returns>A list of all users.</returns>
    public List<User> GetAllUsers()
    {
        Console.WriteLine("Searching for all users:\n");
        var users = _context.Users.ToList();

        users.ForEach(x => Console.WriteLine(x.Username));

        Console.WriteLine($"There are {users.Count} users\n");

        return users;
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