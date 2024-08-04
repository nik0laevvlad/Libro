using Libro.Api.Models;

namespace Libro.Api.Infrastructure.Repositories;

public interface IAuthorRepository
{
    Task AddAsync(Author book);
    Task<Author[]> GetAllAsync();
    Task<Author> GetAsync(Guid id);
    Task DeleteAsync(Guid id);
}