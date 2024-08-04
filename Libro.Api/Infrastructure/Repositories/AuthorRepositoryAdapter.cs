using Libro.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Libro.Api.Infrastructure.Repositories;

public class AuthorRepositoryAdapter(AppDbContext dbContext) : IAuthorRepository
{
    public async Task AddAsync(Author book)
    {
        await dbContext.AddAsync(book);
    }

    public async Task<Author[]> GetAllAsync()
    {
        return await dbContext.Authors.ToArrayAsync();
    }

    public async Task<Author> GetAsync(Guid id)
    {
        return await dbContext.Authors.FindAsync(id) ?? throw new Exception("Author not found");
    }

    public async Task DeleteAsync(Guid id)
    {
        var author = await GetAsync(id);
        dbContext.Authors.Remove(author);
    }
}