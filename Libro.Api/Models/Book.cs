namespace Libro.Api.Models;

public class Book
{
    public Guid Id { get; protected set; }
    public string Title { get; protected set; }
    public string Author { get; protected set; }

    private Book(Guid id, string title, string author)
    {
        Id = id;
        Title = title;
        Author = author;
    }

    internal void Update(string title, string author)
    {
        Title = title;
        Author = author;
    }

    public static Book New(string title, string author)
    {
        var book = new Book(Guid.NewGuid(), title, author);
        return book;
    }
}