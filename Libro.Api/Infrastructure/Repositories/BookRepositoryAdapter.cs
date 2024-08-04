using Libro.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Libro.Api.Infrastructure.Repositories;

public class BookRepositoryAdapter(AppDbContext dbContext) : IBookRepository
{
    public async Task AddAsync(Book book)
    {
        await dbContext.AddAsync(book);
    }

    public async Task<Book[]> GetAllAsync()
    {
        return await dbContext.Books.ToArrayAsync();
    }

    public async Task<Book> GetAsync(Guid id)
    {
        return await dbContext.Books.FindAsync(id) ?? throw new Exception("Book not found");
    }

    public async Task DeleteAsync(Guid id)
    {
        var book = await GetAsync(id);
        dbContext.Books.Remove(book);
    }
}