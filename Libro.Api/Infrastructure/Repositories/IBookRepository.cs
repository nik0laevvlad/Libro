using Libro.Api.Models;

namespace Libro.Api.Infrastructure.Repositories;

public interface IBookRepository
{
    Task AddAsync(Book book);
    Task<Book[]> GetAllAsync();
    Task<Book> GetAsync(Guid id);
    Task DeleteAsync(Guid id);
}