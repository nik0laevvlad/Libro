using Libro.Api.Models;

namespace Libro.Api.Infrastructure.Repositories;

public interface IBookRepository
{
    Task AddAsync(Book book);
}