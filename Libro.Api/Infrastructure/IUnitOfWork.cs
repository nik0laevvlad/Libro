namespace Libro.Api.Infrastructure;

public interface IUnitOfWork
{
    Task CommitAsync();
}