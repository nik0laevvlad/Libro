using Libro.Api.Models;

namespace Libro.Api.Infrastructure.Repositories;

public interface ILoanRepository
{
    Task AddAsync(Loan loan);
    Task<Loan[]> GetAllAsync(Guid? userId = null);
    Task<Loan> GetAsync(Guid id);
    Task DeleteAsync(Guid id);
}