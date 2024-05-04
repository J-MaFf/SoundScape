using COMPSCI366.Models;

public class UserController
{
    private readonly CompsciprojectContext _context;

    public UserController()
    {
        _context = new CompsciprojectContext();
    }

    public List<User> ListAllUsers()
    {
        Console.WriteLine("Searching for all users:\n");
        var users = _context.Users.ToList();

        users.ForEach(x => Console.WriteLine(x.Username));

        Console.WriteLine($"There are {users.Count} users\n");

        return users;
    }

    public User GetUser(string username)
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

    public User CreateNewUser(string username, string password)
    {
        Console.WriteLine($"Creating new user {username}\n");
        User newUser = new();
        newUser.Username = username;
        newUser.Password = password;
        newUser.MinutesListened = 0;

        // Check to see if username already exists in the database
        if (GetUser(username) != null)
        {
            Console.WriteLine($"{username} is already a user\n");
            return null;
        }


        // Add user to database
        _context.Users.Add(newUser);
        // Save changes
        _context.SaveChanges();

        return newUser;
    }

    public void DeleteUser(string username)
    {
        Console.WriteLine($"Attempting to delete {username}\n");

        var userToDelete = GetUser(username);

        if (userToDelete == null)
        {
            Console.WriteLine($"Cannont delete {username} because that user does not exist\n");
            return;
        }

        _context.Users.Remove(userToDelete);
        _context.SaveChanges();



        Console.WriteLine($"{username} deleted");
    }
}