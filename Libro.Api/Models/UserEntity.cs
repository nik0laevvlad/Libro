using Microsoft.EntityFrameworkCore;

namespace Libro.Api.Models;

[Index(nameof(Email), nameof(Username), IsUnique = true)]
public class UserEntity
{
    protected UserEntity()
    {
    }

    public Guid Id { get; protected set; }
    public string Username { get; protected set; } = null!;
    public string Email { get; protected set; } = null!;
    public string Password { get; protected set; } = null!;

    private UserEntity(Guid id, string username, string email, string password)
    {
        Id = id;
        Username = username;
        Email = email;
        Password = password;
    }

    public static UserEntity New(string username, string email, string password)
    {
        var user = new UserEntity(Guid.NewGuid(), username, email, password);
        return user;
    }
}