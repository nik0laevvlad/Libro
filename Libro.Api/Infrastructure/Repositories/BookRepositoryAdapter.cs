using Libro.Api.Models;

namespace Libro.Api.Infrastructure.Repositories;

public class BookRepositoryAdapter(AppDbContext dbContext) : IBookRepository
{
    public async Task AddAsync(Book book)
    {
        await dbContext.AddAsync(book);
    }
}