namespace Libro.Api.Models;

public class Author
{
    public Guid Id { get; protected set; }
    public string FirstName { get; protected set; }
    public string LastName { get; protected set; }

    private Author(Guid id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    internal void Update(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    internal static Author New(string firstName, string lastName)
    {
        var author = new Author(Guid.NewGuid(), firstName, lastName);
        return author;
    }
}